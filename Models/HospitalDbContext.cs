using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext() : base("hospitalDbConnection")
        { }
        public DbSet<Doctor> Doctors { get; set; }
        
        public DbSet<Billing> Billings { get; set; }
        public DbSet<Patient> Patients { get; set; }
               
        public DbSet<AdminCred> AdminCreds { get; set; }

       
    }
}