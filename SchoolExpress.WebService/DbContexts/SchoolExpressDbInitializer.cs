using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Reflection;

namespace SchoolExpress.WebService.DbContexts
{
    public class SchoolExpressDbInitializer : CreateDatabaseIfNotExists<SchoolExpressDbContext>
    {
        protected override void Seed(SchoolExpressDbContext context)
        {        
            base.Seed(context);
        }

        public void Test(SchoolExpressDbContext context)
        {
            List<PropertyInfo> dbSetProperties = context.GetDbSetProperties();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Data" + Path.DirectorySeparatorChar;

        }
    }
}
