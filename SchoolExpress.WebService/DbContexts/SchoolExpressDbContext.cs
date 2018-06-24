using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.WebService.DbContexts
{
    public class SchoolExpressDbContext : IdentityDbContext<IdentityUser>
    {
        public static readonly ConnectionStringSettings ConnectionStringSettings = @ConfigurationManager.ConnectionStrings["SchoolExpressConnection"];

        public SchoolExpressDbContext() : base(ConnectionStringSettings.ConnectionString)
        {
            string providerName = ConnectionStringSettings.ProviderName;
            if (providerName == "System.Data.SqlClient")
            {
                DbProviderFactory providerFactory = DbProviderFactories.GetFactory(providerName);


                //= new System.Data.Entity.Infrastructure.SqlConnectionFactory();
            }

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer(new SchoolExpressInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Properties<string>()
                .Configure(s => s.HasMaxLength(100));
            modelBuilder.Entity<IdentityUser>().Property(p => p.Id).HasMaxLength(36);
            modelBuilder.Entity<IdentityRole>().Property(p => p.Id).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserClaim>().Property(p => p.UserId).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserLogin>().Property(p => p.UserId).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserRole>().Property(p => p.UserId).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserRole>().Property(p => p.RoleId).HasMaxLength(36);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            IEnumerable<Type> typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                               type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (Type type in typesToRegister)
            {
                dynamic configInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configInstance);
            }
        }
    }
}