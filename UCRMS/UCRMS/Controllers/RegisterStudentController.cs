using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using UCRMS.BLL;
using UCRMS.Models;

namespace UCRMS.Controllers
{
    public class RegisterStudentController : Controller
    {
        private DepartmentManager _DepartmentManager = new DepartmentManager();
        private RegisterStudentManager _registerStudentManager=new RegisterStudentManager();
        //
        // GET: /RegisterStudent/
        public ActionResult RegisterStudent()
        {
            GetDepartment();
            return View();
        }
            [HttpGet]
        private void GetDepartment()
        {
            List<Department> dtpList = _DepartmentManager.GetShowDepartmentDetails();
            ViewBag.DpList = new SelectList(dtpList, "ID", "Name");
        }
                [HttpPost]
        public ActionResult RegisterStudent(RegisterStudents registerStudent)
        {
            string AutoID = "";
            string DepartMent = DataTransfection.GetShowSingleValueString("Name", "ID", "Department",
                registerStudent.DeptID);
            int Count = DataTransfection.GetShowSingleValueInt("Count(*)", "Student_Registation");
            if (DepartMent.Length > 3)
            {
                AutoID = DepartMent.Substring(0, 2);
            }
            else
            {
                AutoID = DepartMent.Substring(0, 1); 
            }

            AutoID = AutoID.ToUpper() + "-" + DateTime.Now.Year + "-00" + (Count+1);
            

            string Alart = _registerStudentManager.SaveStudent(registerStudent,AutoID);
            ViewBag.Message = Alart;
                    GetDepartment();
            return View();
        }
        
    }
}