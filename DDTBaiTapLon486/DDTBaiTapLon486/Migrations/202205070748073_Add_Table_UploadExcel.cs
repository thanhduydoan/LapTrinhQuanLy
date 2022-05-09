namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Table_UploadExcel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UploadExcels",
                c => new
                    {
                        STT = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.STT);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UploadExcels");
        }
    }
}
