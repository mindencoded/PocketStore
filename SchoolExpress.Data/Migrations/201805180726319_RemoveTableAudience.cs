namespace SchoolExpress.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RemoveTableAudience : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Audience");
        }

        public override void Down()
        {
            CreateTable(
                    "dbo.Audience",
                    c => new
                    {
                        ClientId = c.String(nullable: false, maxLength: 36),
                        Base64Secret = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ClientId);
        }
    }
}