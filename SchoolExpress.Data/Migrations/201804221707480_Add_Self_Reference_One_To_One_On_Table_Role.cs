using System.Data.Entity.Migrations;

namespace SchoolExpress.Data.Migrations
{
    public partial class Add_Self_Reference_One_To_One_On_Table_Role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Role", "ParentRolId", c => c.Int());
            CreateIndex("dbo.Role", "ParentRolId");
            AddForeignKey("dbo.Role", "ParentRolId", "dbo.Role", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Role", "ParentRolId", "dbo.Role");
            DropIndex("dbo.Role", new[] { "ParentRolId" });
            DropColumn("dbo.Role", "ParentRolId");
        }
    }
}
