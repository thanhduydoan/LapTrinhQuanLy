namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkmodel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Payments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.String(nullable: false, maxLength: 128),
                        Makhachhang = c.String(),
                        Sanphamid = c.Int(nullable: false),
                        Tensanpham = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID);
            
        }
    }
}
