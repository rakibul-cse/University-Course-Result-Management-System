using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;

namespace UCRMS.BLL
{
    public class RegisterStudentManager
    {
        private RegisterStudentGetway _registerStudentGetway=new RegisterStudentGetway();
        internal string SaveStudent(Models.RegisterStudents registerStudent,string AutoID)
        {

            int aTest = _registerStudentGetway.GetValidation(registerStudent.Name);
            if (aTest > 0)
            {
                throw new Exception("this Code already Existed....!!!!!");
            }
            return _registerStudentGetway.SaveStudent(registerStudent,AutoID);
        }
    }
}