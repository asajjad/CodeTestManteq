namespace ManteqCodeTest.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManteqApprovalRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApprovalRequestId = c.Guid(nullable: false),
                        OriginalVersion = c.Int(nullable: false),
                        PatientId = c.String(),
                        PatientName = c.String(),
                        DateOfBirth = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ManteqEvent",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Version = c.Int(nullable: false),
                        AggregateId = c.Guid(nullable: false),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ManteqEvent");
            DropTable("dbo.ManteqApprovalRequest");
        }
    }
}
