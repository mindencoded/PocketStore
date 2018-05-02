using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public interface IAudienceRepository : IRepository<Audience>
    {
        void Add(string name);

        Audience GetByName(string name);
    }
}