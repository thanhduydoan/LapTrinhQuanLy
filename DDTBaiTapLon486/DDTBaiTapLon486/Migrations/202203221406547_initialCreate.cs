namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(maxLength: 30),
                        RoleID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10),
                        RoleName = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Giohangs",
                c => new
                    {
                        MaDonHang = c.Int(nullable: false, identity: true),
                        TenDonHang = c.String(),
                        Tenkhachhang = c.String(),
                        NgayBan = c.DateTime(nullable: false),
                        DonGia = c.Single(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        ThanhTien = c.Single(nullable: false),
                        KhachHang_Makhachhang = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaDonHang)
                .ForeignKey("dbo.KhachHangs", t => t.KhachHang_Makhachhang)
                .Index(t => t.KhachHang_Makhachhang);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        Makhachhang = c.String(nullable: false, maxLength: 128),
                        Tenkhachhang = c.String(),
                        SDT = c.Int(nullable: false),
                        Diachi = c.String(),
                    })
                .PrimaryKey(t => t.Makhachhang);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Giohangs", "KhachHang_Makhachhang", "dbo.KhachHangs");
            DropForeignKey("dbo.Accounts", "RoleID", "dbo.Roles");
            DropIndex("dbo.Giohangs", new[] { "KhachHang_Makhachhang" });
            DropIndex("dbo.Accounts", new[] { "RoleID" });
            DropTable("dbo.KhachHangs");
            DropTable("dbo.Giohangs");
            DropTable("dbo.Roles");
            DropTable("dbo.Accounts");
        }
    }
}
