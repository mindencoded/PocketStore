using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Npgsql;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.DbContexts
{
    public class SchoolExpressDbContext : DbContext
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
                    if (connectionStringBuilder.DataSource.Equals(@"(localdb)\MSSQLLocalDB",
                        StringComparison.OrdinalIgnoreCase))
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
            if (Database.CreateIfNotExists())
            {
                new PopulateDataInitializer().InitializeDatabase(this);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Properties<string>().Configure(s => s.HasMaxLength(100));
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

        public override int SaveChanges()
        {
            ConfigureEntries();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            ConfigureEntries();
            return await base.SaveChangesAsync();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ConfigureEntries();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ConfigureEntries()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.CurrentValues.PropertyNames.Contains("Created"))
                        {
                            entry.Property("Created").CurrentValue = DateTime.Now;
                        }

                        break;
                    case EntityState.Modified:
                        if (entry.CurrentValues.PropertyNames.Contains("Created"))
                        {
                            entry.Property("Created").IsModified = false;
                        }

                        if (entry.CurrentValues.PropertyNames.Contains("LastModified"))
                        {
                            entry.Property("LastModified").CurrentValue = DateTime.Now;
                        }

                        break;
                }
            }
        }
    }
}