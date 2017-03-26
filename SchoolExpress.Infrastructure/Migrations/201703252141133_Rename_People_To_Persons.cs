using System.Data.Entity.Migrations;

namespace SchoolExpress.Infrastructure.Migrations
{
    public partial class Rename_People_To_Persons : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Person", "RoleId", "dbo.Role");
            AddForeignKey("dbo.Person", "RoleId", "dbo.Role", "Id", true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Person", "RoleId", "dbo.Role");
            AddForeignKey("dbo.Person", "RoleId", "dbo.Role", "Id");
        }
    }
}