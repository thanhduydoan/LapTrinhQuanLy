namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_role : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Roleid = c.String(nullable: false, maxLength: 10),
                        Rolename = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Roleid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Roles");
        }
    }
}
