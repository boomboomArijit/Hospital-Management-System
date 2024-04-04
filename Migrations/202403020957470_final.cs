namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Billings",
                c => new
                    {
                        BillID = c.Int(nullable: false, identity: true),
                        TotalBill = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                        PatientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.DoctorID)
                .Index(t => t.PatientID);
            
            AddColumn("dbo.Doctors", "DoctorFees", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "PatientEmailAddress", c => c.String());
            DropColumn("dbo.Doctors", "Experience");
            DropColumn("dbo.Doctors", "AppointmentDays");
            DropColumn("dbo.Patients", "ConfirmPassword");
            DropTable("dbo.Admins");
            DropTable("dbo.Medicines");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineID = c.Int(nullable: false, identity: true),
                        MedicineName = c.String(),
                        MedicineManufact = c.String(),
                        MedicineExpDate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        LoginId = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.LoginId);
            
            AddColumn("dbo.Patients", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Doctors", "AppointmentDays", c => c.String());
            AddColumn("dbo.Doctors", "Experience", c => c.String());
            DropForeignKey("dbo.Billings", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Billings", "DoctorID", "dbo.Doctors");
            DropIndex("dbo.Billings", new[] { "PatientID" });
            DropIndex("dbo.Billings", new[] { "DoctorID" });
            DropColumn("dbo.Patients", "PatientEmailAddress");
            DropColumn("dbo.Doctors", "DoctorFees");
            DropTable("dbo.Billings");
        }
    }
}
