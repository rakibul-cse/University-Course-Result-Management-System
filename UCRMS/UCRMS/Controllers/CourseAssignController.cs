using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS.BLL;
using UCRMS.Models;

namespace UCRMS.Controllers
{
    public class CourseAssignController : Controller
    {
        //
        // GET: /CourseAssign/
        private DepartmentManager _DepartmentManager = new DepartmentManager();
        private TeacherManager _TeacherManager = new TeacherManager();
        private CourseSetupManager _CourseManager = new CourseSetupManager();
        private CourseAssignManager _courseAssignManager=new CourseAssignManager();
       
        [HttpGet]
        public ActionResult CourseAssign()
        {
            DepartmentList();
            return View();
        }
        private void DepartmentList()
        {
            List<Department> dtpList = _DepartmentManager.GetShowDepartmentDetails();
            ViewBag.DpList = new SelectList(dtpList, "ID", "Name");

            List<Teacher> ThpList = _TeacherManager.GetShowTeacherDetails();
            ViewBag.TherList = new SelectList(ThpList, "ID", "Name");

           

            List<CourseSetup> CrsList = _CourseManager.GetAllCourseList("");
            ViewBag.SmList = new SelectList(CrsList, "ID", "Code");

            List<CourseAssign> CourseAssList = _courseAssignManager.GetAllCourseAssainDetails("");
            ViewBag.TeacherList = CourseAssList;    
        }
        public ActionResult CourseAssign(CourseAssign courseAssign)
        {
            string Alart = _courseAssignManager.SaveCourseAssain(courseAssign);
            ViewBag.Message = Alart;
            DepartmentList();
            return View();
        }
	}
}