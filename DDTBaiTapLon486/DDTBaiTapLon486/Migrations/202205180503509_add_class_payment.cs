namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_class_payment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.String(nullable: false, maxLength: 128),
                        Makhachhang = c.String(),
                        Sanphamid = c.Int(nullable: false),
                        Tensanpham = c.String(),
                    })
                .PrimaryKey(t => t.PaymentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Payments");
        }
    }
}
