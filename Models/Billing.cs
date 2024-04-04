using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class Billing
    {
        [Key]
        public int BillID { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; } 
        public string DoctorName { get; set; }

        public int TotalBill { get; set; }    
       
        
        public Doctor doctor { get; set; }  
        public Patient patient { get; set; }    


        
       
    } 
}