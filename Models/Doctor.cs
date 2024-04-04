using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID {  get; set; }


        [Required(ErrorMessage = "DoctorName is Required")]
        [RegularExpression(@"^[a-zA-Z\s]*$*", ErrorMessage ="Only alphabets are allowed.")]
       
        
        public string DoctorName { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$*", ErrorMessage = "Only alphabets are allowed.")]
        public string Specialization { get; set; }

       
        [Required(ErrorMessage = "DoctorFees is Required")]
        [Range(100, 100000, ErrorMessage = "Enter correct fees")]
        public int DoctorFees { get; set; }

        public ICollection<Billing> Billings    { get; set; }
        

       
    }
}