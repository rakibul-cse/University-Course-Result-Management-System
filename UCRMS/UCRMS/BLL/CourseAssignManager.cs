using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;
using UCRMS.Models;

namespace UCRMS.BLL
{
    public class CourseAssignManager
    {
        private CourseAssignGetway _courseAssignGetway=new CourseAssignGetway();
        internal string SaveCourseAssain(CourseAssign courseAssign)
        {
            
            if (courseAssign.CourseName == "")
            {
                throw new Exception("Enter Email ....!!!!!");
            }
            //int aTest = _courseAssignGetway.GetValidation(courseAssign.CourseName);
            //if (aTest > 0)
            //{
            //    throw new Exception("this Code already Existed....!!!!!");
            //}
            return _courseAssignGetway.SaveCourseAssain(courseAssign);
        }

        internal List<CourseAssign> GetAllCourseAssainDetails(string CourseName)
        {
            return _courseAssignGetway.GetAllCourseAssainDetails(CourseName);
        }
    }
}