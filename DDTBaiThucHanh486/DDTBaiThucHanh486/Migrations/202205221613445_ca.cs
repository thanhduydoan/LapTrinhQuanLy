namespace DDTBaiThucHanh486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ca : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CartItems", "SanPhamID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CartItems", "SanPhamID", c => c.Int(nullable: false));
        }
    }
}
