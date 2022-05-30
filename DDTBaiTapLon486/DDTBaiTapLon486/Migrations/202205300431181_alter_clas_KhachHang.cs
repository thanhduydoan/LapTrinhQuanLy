namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_clas_KhachHang : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Giohangs", "SanPhamID", "dbo.SanPhams");
            DropForeignKey("dbo.Giohangs", "KhachHang_Makhachhang", "dbo.KhachHangs");
            DropIndex("dbo.Giohangs", new[] { "SanPhamID" });
            DropIndex("dbo.Giohangs", new[] { "KhachHang_Makhachhang" });
            AddColumn("dbo.SanPhams", "DonGia", c => c.Int(nullable: false));
            AlterColumn("dbo.SanPhams", "SoLuong", c => c.String());
            DropColumn("dbo.SanPhams", "Gia");
            DropTable("dbo.Giohangs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Giohangs",
                c => new
                    {
                        Hinh = c.String(nullable: false, maxLength: 128),
                        SanPhamID = c.Int(nullable: false),
                        Tensanpham = c.String(),
                        DonGia = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        KhachHang_Makhachhang = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Hinh);
            
            AddColumn("dbo.SanPhams", "Gia", c => c.Int(nullable: false));
            AlterColumn("dbo.SanPhams", "SoLuong", c => c.Int(nullable: false));
            DropColumn("dbo.SanPhams", "DonGia");
            CreateIndex("dbo.Giohangs", "KhachHang_Makhachhang");
            CreateIndex("dbo.Giohangs", "SanPhamID");
            AddForeignKey("dbo.Giohangs", "KhachHang_Makhachhang", "dbo.KhachHangs", "Makhachhang");
            AddForeignKey("dbo.Giohangs", "SanPhamID", "dbo.SanPhams", "SanPhamID", cascadeDelete: true);
        }
    }
}
