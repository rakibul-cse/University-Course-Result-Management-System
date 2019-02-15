using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;

namespace UCRMS.BLL
{
    public class EnrollCourseManager
    {
        private EnrollCourseGetway _enrollCourseGetway=new EnrollCourseGetway();
        internal string SaveCourseEnroll(Models.EnrollCourses enrollCourses)
        {
            try
            {
                return _enrollCourseGetway.SaveCourseEnroll(enrollCourses);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}