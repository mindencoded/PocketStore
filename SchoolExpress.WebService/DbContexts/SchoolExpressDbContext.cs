using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Microsoft.AspNet.Identity.EntityFramework;
using Npgsql;

namespace SchoolExpress.WebService.DbContexts
{
    public class SchoolExpressDbContext : IdentityDbContext<IdentityUser>
    {
        private static readonly string ConnectionName;

        public static string ProviderName { get; }

        static SchoolExpressDbContext()
        {
            ConnectionName = ConfigurationManager.AppSettings["SchoolExpressConnection"];
            ConnectionStringSettings connectionStringSettings =
                @ConfigurationManager.ConnectionStrings[ConnectionName];
            string providerName = connectionStringSettings.ProviderName;
            ProviderName = providerName;
            string connectionString = connectionStringSettings.ConnectionString;
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            if (providerName == "Npgsql")
            {
                DbConfiguration.Loaded += (_, a) =>
                {
                    a.ReplaceService<IDbConnectionFactory>((s, k) => new NpgsqlConnectionFactory());
                };
            }

            if (providerName == "System.Data.SqlClient")
            {
                DbConfiguration.Loaded += (_, a) =>
                {
                    if (connectionStringBuilder.DataSource == @"(localdb)\MSSQLLocalDB")
                    {
                        a.ReplaceService<IDbConnectionFactory>((s, k) => new LocalDbConnectionFactory("v11.0"));
                    }
                    else
                    {
                        a.ReplaceService<IDbConnectionFactory>((s, k) => new SqlConnectionFactory());
                    }
                };
            }
        }

        public SchoolExpressDbContext() : base("Name=" + ConnectionName)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            if (!Database.Exists())
            {
                Database.SetInitializer(new SchoolExpressDbInitializer());
                Database.Initialize(true);
            }
            new ExcecuteAlwaysInitializer().InitializeDatabase(this);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            modelBuilder.Entity<IdentityUser>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Properties<string>().Configure(s => s.HasMaxLength(100));
            modelBuilder.Entity<IdentityUser>().Property(p => p.Id).HasMaxLength(36);
            modelBuilder.Entity<IdentityRole>().Property(p => p.Id).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserRole>().Property(p => p.RoleId).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserRole>().Property(p => p.UserId).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserClaim>().Property(p => p.UserId).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserLogin>().Property(p => p.UserId).HasMaxLength(36);
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