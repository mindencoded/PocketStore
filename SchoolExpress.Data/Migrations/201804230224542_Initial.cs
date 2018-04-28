namespace SchoolExpress.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AcademicTerm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        LastModified = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseSchedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        AcademicTermId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicTerm", t => t.AcademicTermId)
                .ForeignKey("dbo.Grade", t => t.GradeId)
                .Index(t => t.AcademicTermId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.CourseScheduleDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        JoinDays = c.String(),
                        CourseScheduleId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        ClassRoomId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassRoom", t => t.ClassRoomId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.CourseSchedule", t => t.CourseScheduleId)
                .ForeignKey("dbo.Person", t => t.TeacherId)
                .Index(t => t.CourseScheduleId)
                .Index(t => t.CourseId)
                .Index(t => t.ClassRoomId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.ClassRoom",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        LastModified = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        GradeId = c.Int(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grade", t => t.GradeId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Hours = c.Int(nullable: false),
                        CostByHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Points = c.Int(nullable: false),
                        CostByPoint = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastModified = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.EnrollmentDetail",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false),
                        EnrollmentId = c.Int(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastModified = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.AssignmentId, t.EnrollmentId })
                .ForeignKey("dbo.Assignment", t => t.AssignmentId)
                .ForeignKey("dbo.Enrollment", t => t.EnrollmentId)
                .Index(t => t.AssignmentId)
                .Index(t => t.EnrollmentId);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InscriptionDate = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StudentId = c.Int(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Document = c.String(),
                        InternalCode = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        LastModified = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseScheduleDetail", "TeacherId", "dbo.Person");
            DropForeignKey("dbo.CourseScheduleDetail", "CourseScheduleId", "dbo.CourseSchedule");
            DropForeignKey("dbo.CourseSchedule", "GradeId", "dbo.Grade");
            DropForeignKey("dbo.Course", "GradeId", "dbo.Grade");
            DropForeignKey("dbo.CourseScheduleDetail", "CourseId", "dbo.Course");
            DropForeignKey("dbo.EnrollmentDetail", "EnrollmentId", "dbo.Enrollment");
            DropForeignKey("dbo.Enrollment", "StudentId", "dbo.Person");
            DropForeignKey("dbo.EnrollmentDetail", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.Assignment", "CourseId", "dbo.Course");
            DropForeignKey("dbo.CourseScheduleDetail", "ClassRoomId", "dbo.ClassRoom");
            DropForeignKey("dbo.CourseSchedule", "AcademicTermId", "dbo.AcademicTerm");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropIndex("dbo.Enrollment", new[] { "StudentId" });
            DropIndex("dbo.EnrollmentDetail", new[] { "EnrollmentId" });
            DropIndex("dbo.EnrollmentDetail", new[] { "AssignmentId" });
            DropIndex("dbo.Assignment", new[] { "CourseId" });
            DropIndex("dbo.Course", new[] { "GradeId" });
            DropIndex("dbo.CourseScheduleDetail", new[] { "TeacherId" });
            DropIndex("dbo.CourseScheduleDetail", new[] { "ClassRoomId" });
            DropIndex("dbo.CourseScheduleDetail", new[] { "CourseId" });
            DropIndex("dbo.CourseScheduleDetail", new[] { "CourseScheduleId" });
            DropIndex("dbo.CourseSchedule", new[] { "GradeId" });
            DropIndex("dbo.CourseSchedule", new[] { "AcademicTermId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropTable("dbo.Grade");
            DropTable("dbo.Person");
            DropTable("dbo.Enrollment");
            DropTable("dbo.EnrollmentDetail");
            DropTable("dbo.Assignment");
            DropTable("dbo.Course");
            DropTable("dbo.ClassRoom");
            DropTable("dbo.CourseScheduleDetail");
            DropTable("dbo.CourseSchedule");
            DropTable("dbo.AcademicTerm");
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
        }
    }
}
