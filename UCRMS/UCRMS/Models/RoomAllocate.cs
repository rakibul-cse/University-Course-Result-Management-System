using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCRMS.Models
{
    public class RoomAllocate
    {
        public int Department { set; get; }
        public int CourseID { set; get; }
        [Required]
        public int RoomNo { set; get; }
        [Required]
        public int Day { set; get; }
         [Required]
        public string From { set; get; }
         [Required]
        public int To { set; get; }
    }
}