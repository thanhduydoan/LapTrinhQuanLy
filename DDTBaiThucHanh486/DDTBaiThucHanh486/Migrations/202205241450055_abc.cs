namespace DDTBaiThucHanh486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CartItems", name: "SanPhamID", newName: "SanPham_SanPhamID");
            RenameIndex(table: "dbo.CartItems", name: "IX_SanPhamID", newName: "IX_SanPham_SanPhamID");
            DropPrimaryKey("dbo.CartItems");
            AddColumn("dbo.CartItems", "Quantity", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CartItems", "Quantity");
            DropColumn("dbo.CartItems", "Hinh");
            DropColumn("dbo.CartItems", "TenSanPham");
            DropColumn("dbo.CartItems", "DonGia");
            DropColumn("dbo.CartItems", "SoLuong");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItems", "SoLuong", c => c.Int(nullable: false));
            AddColumn("dbo.CartItems", "DonGia", c => c.Int(nullable: false));
            AddColumn("dbo.CartItems", "TenSanPham", c => c.String());
            AddColumn("dbo.CartItems", "Hinh", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.CartItems");
            DropColumn("dbo.CartItems", "Quantity");
            AddPrimaryKey("dbo.CartItems", "Hinh");
            RenameIndex(table: "dbo.CartItems", name: "IX_SanPham_SanPhamID", newName: "IX_SanPhamID");
            RenameColumn(table: "dbo.CartItems", name: "SanPham_SanPhamID", newName: "SanPhamID");
        }
    }
}
