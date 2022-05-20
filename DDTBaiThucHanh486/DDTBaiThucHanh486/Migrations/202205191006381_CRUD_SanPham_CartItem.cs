namespace DDTBaiThucHanh486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CRUD_SanPham_CartItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Hinh = c.String(nullable: false, maxLength: 128),
                        SanPhamID = c.Int(nullable: false),
                        TenSanPham = c.String(),
                        DonGia = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Hinh);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        SanPhamID = c.String(nullable: false, maxLength: 128),
                        TenSanPham = c.String(),
                        SoLuong = c.String(),
                        Hinh = c.String(),
                        DonGia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SanPhamID);
            
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.String(nullable: false, maxLength: 128),
                        ProductName = c.String(),
                        ProductPrice = c.Single(nullable: false),
                        ProductDescription = c.String(),
                        ProductImageName = c.String(),
                        CategoryID = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            DropTable("dbo.SanPhams");
            DropTable("dbo.CartItems");
        }
    }
}
