namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Billings",
                c => new
                    {
                        BillID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                        TotalAmount = c.Long(nullable: false),
                        BillingDate = c.DateTime(nullable: false),
                        MedicineBillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .ForeignKey("dbo.MedicineBills", t => t.MedicineBillID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.DoctorID)
                .Index(t => t.MedicineBillID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(),
                        Specialization = c.String(),
                        Experience = c.String(),
                        AppointmentDays = c.String(),
                    })
                .PrimaryKey(t => t.DoctorID);
            
            CreateTable(
                "dbo.MedicineBills",
                c => new
                    {
                        MedicineBillID = c.Int(nullable: false, identity: true),
                        MedicineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineBillID)
                .ForeignKey("dbo.Medicines", t => t.MedicineID, cascadeDelete: true)
                .Index(t => t.MedicineID);
            
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
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        ContactNumber = c.Int(nullable: false),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Billings", "UserID", "dbo.Users");
            DropForeignKey("dbo.MedicineBills", "MedicineID", "dbo.Medicines");
            DropForeignKey("dbo.Billings", "MedicineBillID", "dbo.MedicineBills");
            DropForeignKey("dbo.Billings", "DoctorID", "dbo.Doctors");
            DropIndex("dbo.MedicineBills", new[] { "MedicineID" });
            DropIndex("dbo.Billings", new[] { "MedicineBillID" });
            DropIndex("dbo.Billings", new[] { "DoctorID" });
            DropIndex("dbo.Billings", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Medicines");
            DropTable("dbo.MedicineBills");
            DropTable("dbo.Doctors");
            DropTable("dbo.Billings");
        }
    }
}
