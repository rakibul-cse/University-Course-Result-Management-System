using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;
using UCRMS.Models;

namespace UCRMS.BLL
{
    public class TeacherManager
    {
        private TeacherGetway _TeacherGetway = new TeacherGetway();
        internal string SaveTeacher(Teacher aTeacher)
        {
            if (aTeacher.Name == "")
            {
                throw new Exception("Enter name ....!!!!!");
            }
            if (aTeacher.Email == "")
            {
                throw new Exception("Enter Email ....!!!!!");
            }
            int aTest = _TeacherGetway.GetValidation(aTeacher.Name);
            if (aTest > 0)
            {
                throw new Exception("this Code already Existed....!!!!!");
            }
            return _TeacherGetway.SaveTeacher(aTeacher);
        }

        internal List<Teacher> GetAllTeacherDetails()
        {
            return _TeacherGetway.GetAllTeacherDetails();
        }

        internal List<Teacher> GetShowTeacherDetails()
        {
            return _TeacherGetway.GetShowTeacherDetails();
        }
    }
}