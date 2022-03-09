namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_khachhang_sanpham : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        Makhachhang = c.Int(nullable: false, identity: true),
                        Tenkhachhang = c.String(),
                        SDT = c.Int(nullable: false),
                        Diachi = c.String(),
                    })
                .PrimaryKey(t => t.Makhachhang);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        Sanphamid = c.Int(nullable: false, identity: true),
                        Tensanpham = c.String(),
                        Gia = c.Single(nullable: false),
                        Soluong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sanphamid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SanPhams");
            DropTable("dbo.KhachHangs");
        }
    }
}
