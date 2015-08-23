namespace ManteqCodeTest.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timstmp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ManteqEvent", "TimeStamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ManteqEvent", "TimeStamp");
        }
    }
}
