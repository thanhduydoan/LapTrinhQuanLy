namespace DDTBaiThucHanh486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_CartItem : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CartItems");
        }
    }
}
