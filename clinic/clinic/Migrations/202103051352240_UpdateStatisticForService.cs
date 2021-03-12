namespace clinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStatisticForService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.clinic_service", "Type", c => c.String());
            AddColumn("dbo.clinic_service", "Medicine_id", c => c.Int());
            CreateIndex("dbo.clinic_service", "Medicine_id");
            AddForeignKey("dbo.clinic_service", "Medicine_id", "dbo.medicines", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.clinic_service", "Medicine_id", "dbo.medicines");
            DropIndex("dbo.clinic_service", new[] { "Medicine_id" });
            DropColumn("dbo.clinic_service", "Medicine_id");
            DropColumn("dbo.clinic_service", "Type");
            DropTable("dbo.ServiceStatistics");
        }
    }
}
