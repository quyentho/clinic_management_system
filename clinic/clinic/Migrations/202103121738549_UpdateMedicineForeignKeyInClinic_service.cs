namespace clinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMedicineForeignKeyInClinic_service : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.clinic_service", new[] { "Medicine_id" });
            CreateIndex("dbo.clinic_service", "Medicine_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.clinic_service", new[] { "Medicine_Id" });
            CreateIndex("dbo.clinic_service", "Medicine_id");
        }
    }
}
