using System.Data.Entity.Migrations;

namespace SchoolExpress.Data.Migrations
{
    public partial class Rename_Table_Schedule_And_ScheduleDetail : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Schedule", newName: "CourseSchedule");
            RenameTable(name: "dbo.ScheduleDetail", newName: "CourseScheduleDetail");
            RenameColumn(table: "dbo.CourseScheduleDetail", name: "ScheduleId", newName: "CourseScheduleId");
            RenameIndex(table: "dbo.CourseScheduleDetail", name: "IX_ScheduleId", newName: "IX_CourseScheduleId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CourseScheduleDetail", name: "IX_CourseScheduleId", newName: "IX_ScheduleId");
            RenameColumn(table: "dbo.CourseScheduleDetail", name: "CourseScheduleId", newName: "ScheduleId");
            RenameTable(name: "dbo.CourseScheduleDetail", newName: "ScheduleDetail");
            RenameTable(name: "dbo.CourseSchedule", newName: "Schedule");
        }
    }
}
