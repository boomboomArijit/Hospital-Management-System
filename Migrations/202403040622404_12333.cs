namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12333 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "DoctorName", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "PatientName", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "PatientEmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Password", c => c.String());
            AlterColumn("dbo.Patients", "PatientEmailAddress", c => c.String());
            AlterColumn("dbo.Patients", "PatientName", c => c.String());
            AlterColumn("dbo.Doctors", "DoctorName", c => c.String());
        }
    }
}
