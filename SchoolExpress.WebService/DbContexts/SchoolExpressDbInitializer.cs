using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.DbContexts
{
    public class SchoolExpressDbInitializer : DropCreateDatabaseAlways<SchoolExpressDbContext>
    {
        protected override void Seed(SchoolExpressDbContext context)
        {         
//            string[] sqlFiles =
//{
//                "CleanTables.sql",
//                "ResetIdentities.sql"
//            };

//            foreach (string sqlFile in sqlFiles)
//            {
//                string sqlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SqlQueries",
//                    SchoolExpressDbContext.ProviderName, sqlFile);
//                string sqlContent = File.ReadAllText(sqlPath, Encoding.UTF8);
//                context.Database.ExecuteSqlCommand(sqlContent);
//            }

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
            string dataSourcesPath = ConfigurationManager.AppSettings["DataSourcesPath"];
            if (string.IsNullOrEmpty(dataSourcesPath))
            {
                dataSourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataSources");
            }

            foreach (string entityName in entityNames)
            {
                string sourceFile = Path.Combine(dataSourcesPath, entityName + ".csv");
                Type entityType = entityTypes.FirstOrDefault(t => t.Name == entityName);
                if (File.Exists(sourceFile) && entityType != null)
                {
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
                                for (int i = 0; i < values.Length; i++)
{
                                
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
                }
            }
            base.Seed(context);
        }
    }
}