using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;

namespace SchoolExpress.WebService.DbContexts
{
    public static class DbContextExtensions
    {
        public static string[] GetKeyNames<TEntity>(this DbContext context)
            where TEntity : class
        {
            return context.GetKeyNames(typeof(TEntity));
        }

        public static string[] GetKeyNames(this DbContext context, Type entityType)
        {
            var metadata = ((IObjectContextAdapter) context).ObjectContext.MetadataWorkspace;

            // Get the mapping between CLR types and metadata OSpace
            var objectItemCollection = ((ObjectItemCollection) metadata.GetItemCollection(DataSpace.OSpace));

            // Get metadata for given CLR type
            var entityMetadata = metadata
                .GetItems<EntityType>(DataSpace.OSpace)
                .Single(e => objectItemCollection.GetClrType(e) == entityType);
            return entityMetadata.KeyProperties.Select(p => p.Name).ToArray();
        }

        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }

        public static IEnumerable<dynamic> DynamicListFromSql(this DbContext context, string sql, Dictionary<string, object> Params)
        {
            using (var cmd = context.Database.Connection.CreateCommand())
            {
                cmd.CommandText = sql;
                if (cmd.Connection.State != ConnectionState.Open) { cmd.Connection.Open(); }

                foreach (KeyValuePair<string, object> p in Params)
                {
                    DbParameter dbParameter = cmd.CreateParameter();
                    dbParameter.ParameterName = p.Key;
                    dbParameter.Value = p.Value;
                    cmd.Parameters.Add(dbParameter);
                }

                using (DbDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        IDictionary<string, object> row = new ExpandoObject();
                        for (int fieldCount = 0; fieldCount < dataReader.FieldCount; fieldCount++)
                        {
                            row.Add(dataReader.GetName(fieldCount), dataReader[fieldCount]);
                        }
                        yield return row;
                    }
                }
            }
        }
        
        public static void ExecuteSqlCommand(this DbContext context, string path, params object[] parameters)
        {
            string sqlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            string sqlContent = File.ReadAllText(sqlPath, Encoding.UTF8);
            context.Database.ExecuteSqlCommand(sqlContent, parameters);
        }
    }
}
