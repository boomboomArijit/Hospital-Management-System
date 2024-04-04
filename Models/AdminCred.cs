﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class AdminCred
    {
        [Key]
        public int AdminID    { get; set; }
        
        public string Username { get; set; }

       
        public string Password   { get; set; }
    }
}