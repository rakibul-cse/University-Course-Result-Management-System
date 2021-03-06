﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS.Models
{
    public class StudentResults
    {
        [Display(Name = "Student Reg No")]
        public string RegNo { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Department { set; get; }
        [Display(Name = "Select Course")]
        public string Course { set; get; }
        public string Grade { set; get; }
        public int ID { set; get; }
    }
}