namespace DDTBaiTapLon486.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Person : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.People", newName: "Person");
            AddColumn("dbo.Person", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Address");
            RenameTable(name: "dbo.Person", newName: "People");
        }
    }
}
