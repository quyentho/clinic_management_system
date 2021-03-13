namespace clinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateServiceStatisticModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceStatistics", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ServiceStatistics", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceStatistics", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.ServiceStatistics", "IsActive");
        }
    }
}
