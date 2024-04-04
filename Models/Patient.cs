using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$*", ErrorMessage = "Only alphabets are allowed.")]
        [Required(ErrorMessage = "PatientName is Required")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "PatientAge is Required")]
        [Range(1, 100, ErrorMessage = "Enter Correct Age")]
        public int PatientAge { get; set; }

        [Required(ErrorMessage = "ContactNumber is Required")]
        public int ContactNumber { get; set; }

        [Required(ErrorMessage = "PatientEmailAddress is Required")]
        
        public string PatientEmailAddress { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        public ICollection<Billing> Billings { get; set; }

    }
}
