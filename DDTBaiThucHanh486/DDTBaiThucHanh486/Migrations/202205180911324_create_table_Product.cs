namespace DDTBaiThucHanh486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Product : DbMigration
    {
        public override void Up()
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
            
            DropTable("dbo.CartItems");
        }
        
        public override void Down()
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
            
            DropTable("dbo.Products");
        }
    }
}
