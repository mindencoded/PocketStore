using System.Data.Entity.Migrations;

namespace SchoolExpress.Data.Migrations
{
    public class Rename_Persons_to_People : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Person", "RoleId", "dbo.Role");
            AddForeignKey("dbo.Person", "RoleId", "dbo.Role", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Person", "RoleId", "dbo.Role");
            AddForeignKey("dbo.Person", "RoleId", "dbo.Role", "Id", true);
        }
    }
}