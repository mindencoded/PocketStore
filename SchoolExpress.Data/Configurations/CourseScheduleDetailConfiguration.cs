﻿using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    internal class CourseScheduleDetailConfiguration : EntityTypeConfiguration<CourseScheduleDetail>
    {
        public CourseScheduleDetailConfiguration()
        {
            Ignore(x => x.Days);
            HasRequired(x => x.CourseSchedule)
                .WithMany(x => x.CourseScheduleDetails)
                .HasForeignKey(x => x.CourseScheduleId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Teacher)
                .WithMany(x => x.CourseScheduleDetails)
                .HasForeignKey(x => x.TeacherId)
                .WillCascadeOnDelete(false);
        }
    }
}