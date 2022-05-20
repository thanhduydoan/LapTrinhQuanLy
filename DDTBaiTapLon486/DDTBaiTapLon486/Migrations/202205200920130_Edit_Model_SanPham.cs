namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_Model_SanPham : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Giohangs");
            AddColumn("dbo.Giohangs", "Hinh", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Giohangs", "SanPhamID", c => c.Int(nullable: false));
            AddColumn("dbo.Giohangs", "TenSanPham", c => c.String());
            AddColumn("dbo.SanPhams", "Hinh", c => c.String());
            AlterColumn("dbo.Giohangs", "DonGia", c => c.Int(nullable: false));
            AlterColumn("dbo.SanPhams", "Gia", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Giohangs", "Hinh");
            DropColumn("dbo.Giohangs", "MaDonHang");
            DropColumn("dbo.Giohangs", "TenDonHang");
            DropColumn("dbo.Giohangs", "Tenkhachhang");
            DropColumn("dbo.Giohangs", "NgayBan");
            DropColumn("dbo.Giohangs", "ThanhTien");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Giohangs", "ThanhTien", c => c.Single(nullable: false));
            AddColumn("dbo.Giohangs", "NgayBan", c => c.DateTime(nullable: false));
            AddColumn("dbo.Giohangs", "Tenkhachhang", c => c.String());
            AddColumn("dbo.Giohangs", "TenDonHang", c => c.String());
            AddColumn("dbo.Giohangs", "MaDonHang", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Giohangs");
            AlterColumn("dbo.SanPhams", "Gia", c => c.Single(nullable: false));
            AlterColumn("dbo.Giohangs", "DonGia", c => c.Single(nullable: false));
            DropColumn("dbo.SanPhams", "Hinh");
            DropColumn("dbo.Giohangs", "TenSanPham");
            DropColumn("dbo.Giohangs", "SanPhamID");
            DropColumn("dbo.Giohangs", "Hinh");
            AddPrimaryKey("dbo.Giohangs", "MaDonHang");
        }
    }
}
