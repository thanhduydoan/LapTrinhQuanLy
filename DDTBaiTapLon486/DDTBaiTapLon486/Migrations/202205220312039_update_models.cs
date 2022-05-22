namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_models : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SanPhams");
            AlterColumn("dbo.SanPhams", "Sanphamid", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.SanPhams", "Sanphamid");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SanPhams");
            AlterColumn("dbo.SanPhams", "Sanphamid", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SanPhams", "Sanphamid");
        }
    }
}
