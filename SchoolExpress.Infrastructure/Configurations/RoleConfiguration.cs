﻿using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Infrastructure.Configurations
{
    internal class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            HasOptional(r => r.ParentRole).WithMany().HasForeignKey(r => r.ParentRolId);
        }
    }
}