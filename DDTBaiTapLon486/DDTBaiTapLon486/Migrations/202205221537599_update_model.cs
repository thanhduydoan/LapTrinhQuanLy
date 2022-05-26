namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_model : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Giohangs", "SanPhamID");
            AddForeignKey("dbo.Giohangs", "SanPhamID", "dbo.SanPhams", "SanPhamID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Giohangs", "SanPhamID", "dbo.SanPhams");
            DropIndex("dbo.Giohangs", new[] { "SanPhamID" });
        }
    }
}
