namespace clinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationshipToServiceStatistic : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ServiceStatistics", "ServiceId");
            CreateIndex("dbo.ServiceStatistics", "MedicineId");
            AddForeignKey("dbo.ServiceStatistics", "ServiceId", "dbo.clinic_service", "id", cascadeDelete: true);
            AddForeignKey("dbo.ServiceStatistics", "MedicineId", "dbo.medicines", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceStatistics", "MedicineId", "dbo.medicines");
            DropForeignKey("dbo.ServiceStatistics", "ServiceId", "dbo.clinic_service");
            DropIndex("dbo.ServiceStatistics", new[] { "MedicineId" });
            DropIndex("dbo.ServiceStatistics", new[] { "ServiceId" });
        }
    }
}
