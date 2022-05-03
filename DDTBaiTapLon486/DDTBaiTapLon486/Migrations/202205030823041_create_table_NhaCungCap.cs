namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_NhaCungCap : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NhaCungCaps",
                c => new
                    {
                        MaNhaCungCap = c.String(nullable: false, maxLength: 128),
                        TenNhaCungCap = c.String(),
                    })
                .PrimaryKey(t => t.MaNhaCungCap);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        Sanphamid = c.Int(nullable: false, identity: true),
                        Tensanpham = c.String(),
                        Gia = c.Single(nullable: false),
                        Soluong = c.Int(nullable: false),
                        MaNhaCungCap = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Sanphamid)
                .ForeignKey("dbo.NhaCungCaps", t => t.MaNhaCungCap)
                .Index(t => t.MaNhaCungCap);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "MaNhaCungCap", "dbo.NhaCungCaps");
            DropIndex("dbo.SanPhams", new[] { "MaNhaCungCap" });
            DropTable("dbo.SanPhams");
            DropTable("dbo.NhaCungCaps");
        }
    }
}
