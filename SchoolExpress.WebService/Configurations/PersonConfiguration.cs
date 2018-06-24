﻿using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            HasIndex(x => new {x.IdentityCard}).IsUnique();
            HasIndex(x => new {x.Email}).IsUnique();
            Property(x => x.Email).IsRequired();
            Property(x => x.Name).IsRequired();
        }
    }
}