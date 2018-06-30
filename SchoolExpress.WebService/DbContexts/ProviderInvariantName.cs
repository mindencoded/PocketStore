using System.Data.Entity.Infrastructure;

namespace SchoolExpress.WebService.DbContexts
{
    public class ProviderInvariantName : IProviderInvariantName
    {
        private static string _providerName;

        public ProviderInvariantName(string providerName)
        {
            _providerName = providerName;
        }

        public string Name
        {
            get { return _providerName; }
        }
    }
}