namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _in : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Billings", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Billings", "MedicineBillID", "dbo.MedicineBills");
            DropForeignKey("dbo.MedicineBills", "MedicineID", "dbo.Medicines");
            DropForeignKey("dbo.Billings", "UserID", "dbo.Users");
            DropIndex("dbo.Billings", new[] { "UserID" });
            DropIndex("dbo.Billings", new[] { "DoctorID" });
            DropIndex("dbo.Billings", new[] { "MedicineBillID" });
            DropIndex("dbo.MedicineBills", new[] { "MedicineID" });
            DropTable("dbo.Billings");
            DropTable("dbo.MedicineBills");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MedicineBills",
                c => new
                    {
                        MedicineBillID = c.Int(nullable: false, identity: true),
                        MedicineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineBillID);
            
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
                .PrimaryKey(t => t.BillID);
            
            CreateIndex("dbo.MedicineBills", "MedicineID");
            CreateIndex("dbo.Billings", "MedicineBillID");
            CreateIndex("dbo.Billings", "DoctorID");
            CreateIndex("dbo.Billings", "UserID");
            AddForeignKey("dbo.Billings", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.MedicineBills", "MedicineID", "dbo.Medicines", "MedicineID", cascadeDelete: true);
            AddForeignKey("dbo.Billings", "MedicineBillID", "dbo.MedicineBills", "MedicineBillID", cascadeDelete: true);
            AddForeignKey("dbo.Billings", "DoctorID", "dbo.Doctors", "DoctorID", cascadeDelete: true);
        }
    }
}
