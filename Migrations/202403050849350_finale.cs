namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finale : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Billings", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Billings", "PatientID", "dbo.Patients");
            DropIndex("dbo.Billings", new[] { "DoctorID" });
            DropIndex("dbo.Billings", new[] { "PatientID" });
            RenameColumn(table: "dbo.Billings", name: "DoctorID", newName: "doctor_DoctorID");
            RenameColumn(table: "dbo.Billings", name: "PatientID", newName: "patient_PatientID");
            AddColumn("dbo.Billings", "PatientName", c => c.String());
            AddColumn("dbo.Billings", "PatientAge", c => c.Int(nullable: false));
            AddColumn("dbo.Billings", "DoctorName", c => c.String());
            AlterColumn("dbo.Billings", "doctor_DoctorID", c => c.Int());
            AlterColumn("dbo.Billings", "patient_PatientID", c => c.Int());
            CreateIndex("dbo.Billings", "doctor_DoctorID");
            CreateIndex("dbo.Billings", "patient_PatientID");
            AddForeignKey("dbo.Billings", "doctor_DoctorID", "dbo.Doctors", "DoctorID");
            AddForeignKey("dbo.Billings", "patient_PatientID", "dbo.Patients", "PatientID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Billings", "patient_PatientID", "dbo.Patients");
            DropForeignKey("dbo.Billings", "doctor_DoctorID", "dbo.Doctors");
            DropIndex("dbo.Billings", new[] { "patient_PatientID" });
            DropIndex("dbo.Billings", new[] { "doctor_DoctorID" });
            AlterColumn("dbo.Billings", "patient_PatientID", c => c.Int(nullable: false));
            AlterColumn("dbo.Billings", "doctor_DoctorID", c => c.Int(nullable: false));
            DropColumn("dbo.Billings", "DoctorName");
            DropColumn("dbo.Billings", "PatientAge");
            DropColumn("dbo.Billings", "PatientName");
            RenameColumn(table: "dbo.Billings", name: "patient_PatientID", newName: "PatientID");
            RenameColumn(table: "dbo.Billings", name: "doctor_DoctorID", newName: "DoctorID");
            CreateIndex("dbo.Billings", "PatientID");
            CreateIndex("dbo.Billings", "DoctorID");
            AddForeignKey("dbo.Billings", "PatientID", "dbo.Patients", "PatientID", cascadeDelete: true);
            AddForeignKey("dbo.Billings", "DoctorID", "dbo.Doctors", "DoctorID", cascadeDelete: true);
        }
    }
}
