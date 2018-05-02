using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class AudienceRepository : Repository<Audience>, IAudienceRepository
    {
        public AudienceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void Add(string name)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
            string clientId = Guid.NewGuid().ToString();
            byte[] buffer = Encoding.UTF8.GetBytes(clientId);
            byte[] hash = hashAlgorithm.ComputeHash(buffer);
            string base64Secret = Convert.ToBase64String(hash);
            Audience audience = new Audience {ClientId = clientId, Base64Secret = base64Secret, Name = name};
            DbContext.Set<Audience>().Add(audience);
        }

        public Audience GetByName(string name)
        {
            return DbContext.Set<Audience>().AsNoTracking().FirstOrDefault(x => x.Name == name);
        }
    }
}