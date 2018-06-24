using System.Data.Entity.Infrastructure;

namespace SchoolExpress.WebService.DbContexts
{
    public class CustomProviderInvariantName : IProviderInvariantName
    {
        private static string _providerName;

        public CustomProviderInvariantName(string providerName)
        {
            _providerName = providerName;
        }

        public string Name
        {
            get { return _providerName; }
        }
    }
}