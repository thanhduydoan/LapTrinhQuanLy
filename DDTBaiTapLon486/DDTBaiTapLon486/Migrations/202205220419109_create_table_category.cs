namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.String(nullable: false, maxLength: 128),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            AddColumn("dbo.SanPhams", "CategoryID", c => c.String(maxLength: 128));
            CreateIndex("dbo.SanPhams", "CategoryID");
            AddForeignKey("dbo.SanPhams", "CategoryID", "dbo.Categories", "CategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "CategoryID", "dbo.Categories");
            DropIndex("dbo.SanPhams", new[] { "CategoryID" });
            DropColumn("dbo.SanPhams", "CategoryID");
            DropTable("dbo.Categories");
        }
    }
}
