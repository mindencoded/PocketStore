﻿using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class DegreeRepository : Repository<Degree>, IDegreeRepository
    {
        public DegreeRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }
    }
}