using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCRMS.Models
{
    public class CourseAssign
    {
        public string Department { set; get; }
        public string Teacher { set; get; }
        public decimal CreditTaken { set; get; }
        public decimal RemainCredit { set; get; }
        public string CourseID { set; get; }
        public string CourseName { set; get; }
        public decimal Credit { set; get; }

        public int ID { get; set; }
    }
}