using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS.BLL;
using UCRMS.Models;

namespace UCRMS.Controllers
{
    public class TeacherController : Controller
    {
        private DepartmentManager _DepartmentManager = new DepartmentManager();
        private TeacherManager _TeacherManager = new TeacherManager();
       
        [HttpGet]
        public ActionResult Teacher()
        {
            DepartmentList();

            return View();
        }
        private void DepartmentList()
        {
            List<Department> dtpList = _DepartmentManager.GetShowDepartmentDetails();
            ViewBag.DpList = new SelectList(dtpList, "ID", "Name");

            List<Teacher> ThList = _TeacherManager.GetAllTeacherDetails();
            ViewBag.TeacherList = ThList;
            
        }
        [HttpPost]
        public ActionResult Teacher(Teacher aTeacher)
        {
            string Alart = _TeacherManager.SaveTeacher(aTeacher);
            ViewBag.Message = Alart;
            DepartmentList();
            return View();
        }
	}
}