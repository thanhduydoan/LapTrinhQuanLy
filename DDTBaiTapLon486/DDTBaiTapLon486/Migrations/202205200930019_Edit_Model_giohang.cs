namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_Model_giohang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SanPhams", "Motasanpham", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SanPhams", "Motasanpham");
        }
    }
}
