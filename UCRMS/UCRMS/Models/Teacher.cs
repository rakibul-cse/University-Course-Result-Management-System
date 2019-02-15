using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCRMS.Models
{
    public class Teacher
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContractNo { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string CreditTaken { get; set; }
        public int ID { set; get; }
    }
}