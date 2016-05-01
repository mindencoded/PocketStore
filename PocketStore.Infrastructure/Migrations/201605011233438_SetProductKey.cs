namespace PocketStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetProductKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Product");
            AlterColumn("dbo.Product", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Product", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Product");
            AlterColumn("dbo.Product", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Product", "Title");
        }
    }
}
