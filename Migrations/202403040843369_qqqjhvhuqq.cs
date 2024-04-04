﻿namespace Hospital_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qqqjhvhuqq : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminCreds",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AdminID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminCreds");
        }
    }
}
