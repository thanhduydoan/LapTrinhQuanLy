namespace DDTBaiThucHanh486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hihi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CartItems", "SanPhamID", c => c.String(maxLength: 128));
            CreateIndex("dbo.CartItems", "SanPhamID");
            AddForeignKey("dbo.CartItems", "SanPhamID", "dbo.SanPhams", "SanPhamID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "SanPhamID", "dbo.SanPhams");
            DropIndex("dbo.CartItems", new[] { "SanPhamID" });
            AlterColumn("dbo.CartItems", "SanPhamID", c => c.String());
        }
    }
}
