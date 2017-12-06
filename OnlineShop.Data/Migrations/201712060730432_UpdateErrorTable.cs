namespace OnlineShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateErrorTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Errors");
            AlterColumn("dbo.Errors", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Errors", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Errors");
            AlterColumn("dbo.Errors", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Errors", "ID");
        }
    }
}
