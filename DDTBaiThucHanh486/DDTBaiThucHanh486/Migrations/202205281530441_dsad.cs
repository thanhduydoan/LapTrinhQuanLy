namespace DDTBaiThucHanh486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsad : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "SanPham_SanPhamID", "dbo.SanPhams");
            DropIndex("dbo.CartItems", new[] { "SanPham_SanPhamID" });
            DropTable("dbo.CartItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Quantity = c.Int(nullable: false, identity: true),
                        SanPham_SanPhamID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Quantity);
            
            CreateIndex("dbo.CartItems", "SanPham_SanPhamID");
            AddForeignKey("dbo.CartItems", "SanPham_SanPhamID", "dbo.SanPhams", "SanPhamID");
        }
    }
}
