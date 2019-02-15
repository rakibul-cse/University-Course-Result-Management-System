using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS.Models
{
    public class RegisterStudents
    {
        
        [Display(Name = "Student Name")]
        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Maximum 7 character and minimum 2 character")]
        public string Name { set; get; }
        [EmailAddress]   
        public string Email  { set; get; }
        [Display(Name ="Contract No")]
        [Required]
        public string ContractNo { set; get; }
        [Display(Name = "Department")]
        public string DeptID { set; get; }  
        public string Address { set; get; }
        public string Date { set; get; }
        public int ID { set; get; }
        public string RegNo { set; get; }


    }
}