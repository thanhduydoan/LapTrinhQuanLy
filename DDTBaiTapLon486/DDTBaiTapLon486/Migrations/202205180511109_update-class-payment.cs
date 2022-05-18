namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateclasspayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "Price");
        }
    }
}
