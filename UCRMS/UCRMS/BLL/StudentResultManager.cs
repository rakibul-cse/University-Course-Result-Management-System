using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCRMS.DAL;

namespace UCRMS.BLL
{
    public class StudentResultManager
    {
        private StudentResultGetway _studentResultGetway=new StudentResultGetway();
        internal List<Models.StudentResults> GetAllResultGradet(string Grade)
        {
            return _studentResultGetway.GetAllResultGradet(Grade);
        }

        internal string SaveStudentResult(Models.StudentResults studentResults)
        {
            try
            {
               

            }
            catch (Exception)
            {
                
                throw;
            }
            return _studentResultGetway.SaveStudentResult(studentResults);
        }
    }
}