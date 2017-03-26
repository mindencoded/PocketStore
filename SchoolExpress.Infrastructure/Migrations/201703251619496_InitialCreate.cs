using System.Data.Entity.Migrations;

namespace SchoolExpress.Infrastructure.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.AcademicTerm",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Description = c.String(),
                        LastModified = c.DateTime(false),
                        Created = c.DateTime(false),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Schedule",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Description = c.String(),
                        AcademicTermId = c.Int(false),
                        GradeId = c.Int(false),
                        LastModified = c.DateTime(false),
                        Created = c.DateTime(false),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicTerm", t => t.AcademicTermId, true)
                .ForeignKey("dbo.Grade", t => t.GradeId, true)
                .Index(t => t.AcademicTermId)
                .Index(t => t.GradeId);

            CreateTable(
                    "dbo.Grade",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Description = c.String(),
                        LastModified = c.DateTime(false),
                        Created = c.DateTime(false),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Course",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Description = c.String(),
                        GradeId = c.Int(false),
                        LastModified = c.DateTime(false),
                        Created = c.DateTime(false),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grade", t => t.GradeId, true)
                .Index(t => t.GradeId);

            CreateTable(
                    "dbo.Assignment",
                    c => new
                    {
                        Id = c.Int(false, true),
                        CourseId = c.Int(false),
                        Hours = c.Int(false),
                        CostByHour = c.Decimal(false, 18, 2),
                        Points = c.Int(false),
                        CostByPoint = c.Decimal(false, 18, 2),
                        LastModified = c.DateTime(false),
                        Created = c.DateTime(false),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId, true)
                .Index(t => t.CourseId);

            CreateTable(
                    "dbo.EnrollmentDetail",
                    c => new
                    {
                        AssignmentId = c.Int(false),
                        EnrollmentId = c.Int(false),
                        Discount = c.Decimal(false, 18, 2),
                        LastModified = c.DateTime(false),
                        Created = c.DateTime(false),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => new {t.AssignmentId, t.EnrollmentId})
                .ForeignKey("dbo.Assignment", t => t.AssignmentId)
                .ForeignKey("dbo.Enrollment", t => t.EnrollmentId)
                .Index(t => t.AssignmentId)
                .Index(t => t.EnrollmentId);

            CreateTable(
                    "dbo.Enrollment",
                    c => new
                    {
                        Id = c.Int(false, true),
                        InscriptionDate = c.DateTime(false),
                        TotalAmount = c.Decimal(false, 18, 2),
                        StudentId = c.Int(false),
                        LastModified = c.DateTime(false),
                        Created = c.DateTime(false),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.StudentId)
                .Index(t => t.StudentId);

            CreateTable(
                    "dbo.Person",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Document = c.String(),
                        InternalCode = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(false),
                        RoleId = c.Int(false),
                        LastModified = c.DateTime(false),
                        Created = c.DateTime(false),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, true)
                .Index(t => t.RoleId);

            CreateTable(
                    "dbo.Role",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Description = c.String(),
                        LastModified = c.DateTime(false),
                        Created = c.DateTime(false),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.ScheduleDetail",
                    c => new
                    {
                        Id = c.Int(false, true),
                        StartTime = c.Time(false, 7),
                        EndTime = c.Time(false, 7),
                        JoinDays = c.String(),
                        ScheduleId = c.Int(false),
                        CourseId = c.Int(false),
                        ClassRoomId = c.Int(false),
                        TeacherId = c.Int(false),
                        LastModified = c.DateTime(false),
                        Created = c.DateTime(false),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassRoom", t => t.ClassRoomId, true)
                .ForeignKey("dbo.Course", t => t.CourseId, true)
                .ForeignKey("dbo.Schedule", t => t.ScheduleId)
                .ForeignKey("dbo.Person", t => t.TeacherId)
                .Index(t => t.ScheduleId)
                .Index(t => t.CourseId)
                .Index(t => t.ClassRoomId)
                .Index(t => t.TeacherId);

            CreateTable(
                    "dbo.ClassRoom",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Description = c.String(),
                        LastModified = c.DateTime(false),
                        Created = c.DateTime(false),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.User",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        Password = c.String(),
                        PersonId = c.Int(false),
                        LastModified = c.DateTime(false),
                        Created = c.DateTime(false),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId, true)
                .Index(t => t.PersonId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "GradeId", "dbo.Grade");
            DropForeignKey("dbo.Course", "GradeId", "dbo.Grade");
            DropForeignKey("dbo.EnrollmentDetail", "EnrollmentId", "dbo.Enrollment");
            DropForeignKey("dbo.Enrollment", "StudentId", "dbo.Person");
            DropForeignKey("dbo.User", "PersonId", "dbo.Person");
            DropForeignKey("dbo.ScheduleDetail", "TeacherId", "dbo.Person");
            DropForeignKey("dbo.ScheduleDetail", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.ScheduleDetail", "CourseId", "dbo.Course");
            DropForeignKey("dbo.ScheduleDetail", "ClassRoomId", "dbo.ClassRoom");
            DropForeignKey("dbo.Person", "RoleId", "dbo.Role");
            DropForeignKey("dbo.EnrollmentDetail", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.Assignment", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Schedule", "AcademicTermId", "dbo.AcademicTerm");
            DropIndex("dbo.User", new[] {"PersonId"});
            DropIndex("dbo.ScheduleDetail", new[] {"TeacherId"});
            DropIndex("dbo.ScheduleDetail", new[] {"ClassRoomId"});
            DropIndex("dbo.ScheduleDetail", new[] {"CourseId"});
            DropIndex("dbo.ScheduleDetail", new[] {"ScheduleId"});
            DropIndex("dbo.Person", new[] {"RoleId"});
            DropIndex("dbo.Enrollment", new[] {"StudentId"});
            DropIndex("dbo.EnrollmentDetail", new[] {"EnrollmentId"});
            DropIndex("dbo.EnrollmentDetail", new[] {"AssignmentId"});
            DropIndex("dbo.Assignment", new[] {"CourseId"});
            DropIndex("dbo.Course", new[] {"GradeId"});
            DropIndex("dbo.Schedule", new[] {"GradeId"});
            DropIndex("dbo.Schedule", new[] {"AcademicTermId"});
            DropTable("dbo.User");
            DropTable("dbo.ClassRoom");
            DropTable("dbo.ScheduleDetail");
            DropTable("dbo.Role");
            DropTable("dbo.Person");
            DropTable("dbo.Enrollment");
            DropTable("dbo.EnrollmentDetail");
            DropTable("dbo.Assignment");
            DropTable("dbo.Course");
            DropTable("dbo.Grade");
            DropTable("dbo.Schedule");
            DropTable("dbo.AcademicTerm");
        }
    }
}