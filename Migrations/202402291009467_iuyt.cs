namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iuyt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Password", c => c.String());
            AddColumn("dbo.Patients", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "ConfirmPassword");
            DropColumn("dbo.Patients", "Password");
        }
    }
}
