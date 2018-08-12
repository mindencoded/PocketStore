using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.DbContexts
{
    public class SchoolExpressDbInitializer : DropCreateDatabaseAlways<SchoolExpressDbContext>
    {
        protected override void Seed(SchoolExpressDbContext context)
        {         
            string[] entityNames =
            {
                "Campus",
                "ClassRoom",
                "Course",
                "Degree",
                "Career",
                "CareerDetail",
                "Module",
                "Period",
                "Person",
                "Speaker",
                "Student",
                "CareerSchedule",
                "CareerScheduleDetail",
                "Enrollment",
                "EnrollmentDetail"
            };

            IList<Type> entityTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IEntity).IsAssignableFrom(p)).ToList();
            string dataSourcesPath = ConfigurationManager.AppSettings["DataSources"];
            if (string.IsNullOrEmpty(dataSourcesPath))
            {
                dataSourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataSources", SchoolExpressDbContext.ProviderName, "Csv");
            }

            foreach (string entityName in entityNames)
            {
                string sourceFile = Path.Combine(dataSourcesPath, entityName + ".csv");
                Type entityType = entityTypes.FirstOrDefault(t => t.Name == entityName);
                if (File.Exists(sourceFile) && entityType != null)
                {
                    bool tableHasIdentity = false;

                    if (SchoolExpressDbContext.ProviderName == "System.Data.SqlClient")
                    {
                        tableHasIdentity = context.Database.SqlQuery<int>("SELECT OBJECTPROPERTY(OBJECT_ID('" + entityName + "'), 'TableHasIdentity')").Single() == 1;
                        if (tableHasIdentity)
                        {
                            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT " + entityName + " ON;");
                        }
                    }

                    using (StreamReader file = new StreamReader(sourceFile))
                    {
                        string line;
                        int counter = 0;
                        string[] properties = { };
                        while ((line = file.ReadLine()) != null)
                        {
                            if (counter == 0)
                            {
                                properties = line.Split('|');
                            }
                            else
                            {
                                object entity = Activator.CreateInstance(entityType);
                                string[] values = line.Split('|');
                                for (int i = 0; i < values.Length; i++) {                               
                                    PropertyInfo propertyInfo = entityType.GetProperty(properties[i]);
                                    if (propertyInfo != null)
                                    {
                                        object value;
                                        string strValue = values[i].Trim('"').Trim();
                                        if (propertyInfo.PropertyType == typeof(bool))
                                        {
                                            value = ConversionTool.ConvertBoolean(strValue);
                                        }
                                        else if (propertyInfo.PropertyType == typeof(bool?))
                                        {
                                            value = ConversionTool.ConvertNullableBoolean(strValue);
                                        }
                                        else if (propertyInfo.PropertyType == typeof(TimeSpan))
                                        {
                                            value = ConversionTool.ConvertTimeSpan(strValue);
                                        }
                                        else if (propertyInfo.PropertyType == typeof(TimeSpan?))
                                        {
                                            value = ConversionTool.ConvertNullableTimeSpan(strValue);
                                        }
                                        else if (propertyInfo.PropertyType == typeof(DateTime))
                                        {
                                            value = ConversionTool.ConvertDateTime(strValue);
                                        }
                                        else if (propertyInfo.PropertyType == typeof(DateTime?))
                                        {
                                            value = ConversionTool.ConvertNullbleDateTime(strValue);
                                        }
                                        else
                                        {
                                            value = Convert.ChangeType(strValue, propertyInfo.PropertyType);
                                        }

                                        propertyInfo.SetValue(entity, value, null);
                                    }
                                }

                                context.Set(entityType).Add(entity);
                            }

                            counter++;
                        }
                    }

                    context.SaveChanges();
               
                    if (SchoolExpressDbContext.ProviderName == "System.Data.SqlClient" && tableHasIdentity)
                    {
                        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT " + entityName + " OFF;");
                    }

                    if (SchoolExpressDbContext.ProviderName == "Npgsql")
                    {
                        IList<dynamic> results = context.DynamicListFromSql("SELECT table_schema, table_name, column_name FROM information_schema.columns WHERE column_default LIKE 'nextval%' AND table_name = '"+ entityName + "';", new Dictionary<string, object>()).ToList();
                        foreach (var result in results)
                        {
                            context.Database.SqlQuery<int>("SELECT setval(pg_get_serial_sequence('\"" + result.table_schema + "\".\"" + result.table_name + "\"', '" + result.column_name + "'), CAST((SELECT MAX(\"" + result.column_name + "\") FROM \"" + result.table_schema + "\".\"" + result.table_name + "\") AS INTEGER));");
                        }
                    }
                }
            }
            base.Seed(context);
        }
    }
}