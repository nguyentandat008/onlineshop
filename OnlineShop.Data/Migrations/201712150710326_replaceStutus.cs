namespace OnlineShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replaceStutus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductCategories", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pages", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.PostCategories", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "Stutus");
            DropColumn("dbo.ProductCategories", "Stutus");
            DropColumn("dbo.Pages", "Stutus");
            DropColumn("dbo.PostCategories", "Stutus");
            DropColumn("dbo.Posts", "Stutus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Stutus", c => c.Boolean(nullable: false));
            AddColumn("dbo.PostCategories", "Stutus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pages", "Stutus", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductCategories", "Stutus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "Stutus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Posts", "Status");
            DropColumn("dbo.PostCategories", "Status");
            DropColumn("dbo.Pages", "Status");
            DropColumn("dbo.ProductCategories", "Status");
            DropColumn("dbo.Products", "Status");
        }
    }
}
