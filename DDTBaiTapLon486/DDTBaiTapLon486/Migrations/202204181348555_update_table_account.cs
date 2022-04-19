namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_account : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "RoleID", "dbo.Roles");
            DropIndex("dbo.Accounts", new[] { "RoleID" });
            AlterColumn("dbo.Accounts", "RoleID", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.Accounts", "RoleID");
            AddForeignKey("dbo.Accounts", "RoleID", "dbo.Roles", "RoleID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "RoleID", "dbo.Roles");
            DropIndex("dbo.Accounts", new[] { "RoleID" });
            AlterColumn("dbo.Accounts", "RoleID", c => c.String(maxLength: 10));
            CreateIndex("dbo.Accounts", "RoleID");
            AddForeignKey("dbo.Accounts", "RoleID", "dbo.Roles", "RoleID");
        }
    }
}
