using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Dynamic;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected DbContext DbContext { get; }
        
        protected DbSet<T> DbSet { get; }
        
        public virtual IQueryable<T> GetQueryable()
        {
            return DbSet;
        }
       
        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Added;
            else
                DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
                DbSet.Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Update(ExpandoObject expObj)
        {
            T instance = Activator.CreateInstance<T>();
            foreach (KeyValuePair<string, object> kvp in expObj)
            {
                PropertyInfo propertyInfo = typeof(T).GetProperty(kvp.Key);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(instance, Convert.ChangeType(kvp.Value, propertyInfo.PropertyType));
                }
                else
                {
                    throw new Exception(string.Format("The member name \"{0}\" does not belong to \"{1}\".", kvp.Key,
                        typeof(T).Name));
                }
            }
           string[] keyNames = DbContext.GetKeyNames<T>();
            DbEntityEntry entry = DbContext.Entry(instance);
            IEntity entity = instance as IEntity;
            if (entity != null)
            {
                object[] ids = entity.GetId();
                IList<string> conditions = new List<string>();
                IList<object> parameters = new List<object>();
                for (int i = 0; i < keyNames.Length; i++)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(keyNames[i]);
                    if (propertyInfo != null)
                    {
                        StringBuilder sb =new StringBuilder().Append(keyNames[i]).Append(" == @").Append(i);         
                        conditions.Add(sb.ToString());
                        parameters.Add(Convert.ChangeType(ids[i], propertyInfo.PropertyType));
                    }
                }

                string expression = string.Join(" AND ", conditions.ToArray());
                T local = DbSet.Local.Where(expression, parameters.ToArray()).FirstOrDefault();
                if (local != null)
                {
                    DbContext.Entry(local).State = EntityState.Detached;
                }
            }


            if (entry.State == EntityState.Detached)
            {
                DbSet.Attach(instance);
            }
            
            /*foreach (var propertyName in entry.CurrentValues.PropertyNames)
            {
                Console.WriteLine("Property Name: {0}", propertyName);
                var orgVal = entry.OriginalValues[propertyName];
                Console.WriteLine("     Original Value: {0}", orgVal);
                var curVal = entry.CurrentValues[propertyName];
                Console.WriteLine("     Current Value: {0}", curVal);
            }*/
            
            foreach (KeyValuePair<string, object> kvp in expObj)
            {            
                if (!keyNames.Contains(kvp.Key))
                {
                    DbPropertyEntry propertyEntry = entry.Property(kvp.Key);
                    DbValidationError[] validationErrors = propertyEntry.GetValidationErrors().ToArray();
                    if (validationErrors.Length == 0)
                    {
                        propertyEntry.IsModified = true;
                    }
                    else
                    {                      
                        DbEntityValidationResult validationResult = new DbEntityValidationResult(entry, validationErrors);
                        throw new DbEntityValidationException(validationErrors.First().ErrorMessage, new [] {validationResult} );
                    }
                }
            }
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Delete(object id)
        {
            T entity = DbSet.Find(id);
            if (entity != null)
            {
                DbContext.Entry(entity).State = EntityState.Deleted;
            }    
        }
        
        public virtual async Task DeleteAsync(object id)
        {
            T entity = await DbSet.FindAsync(id);
            if (entity != null)
            {
                DbContext.Entry(entity).State = EntityState.Deleted;
            }    
        }
        
        public void Detach(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Detached;
        }

        public virtual T Find(object id)
        {
            return DbSet.Find(id);
        }
        
        public virtual async Task<T> FindAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}