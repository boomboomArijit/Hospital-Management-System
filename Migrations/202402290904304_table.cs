namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        LoginId = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.LoginId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                        PatientAge = c.Int(nullable: false),
                        ContactNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientID);
            
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
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
            
            DropTable("dbo.Patients");
            DropTable("dbo.Admins");
        }
    }
}
