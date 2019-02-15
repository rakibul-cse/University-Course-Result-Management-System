using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS.Models;

namespace UCRMS.Controllers
{
    public class CourseController : Controller
    {
      private CourseSetupManager _courseManager = new CourseSetupManager();
      private DepartmentManager _DepartmentManager = new DepartmentManager();
        //
        // GET: /Course/
         [HttpGet]
        public ActionResult Course()
        {
            DepartmentList();
            //ViewBag.DepartmentList = _courseManager.GetDepartmentList();           

            return View();              
        }    
         private void DepartmentList()
         {
             List<Department> dtpList = _DepartmentManager.GetShowDepartmentDetails();
             ViewBag.DpList = new SelectList(dtpList, "ID", "Name");
             //ViewBag.DpList = dtpList;
             List<Semester> SmsList = _DepartmentManager.GetShowSemesterDetails();
             ViewBag.SmList = new SelectList(SmsList, "ID", "Name");

             List<CourseSetup> CrsList = _courseManager.GetAllCourseList("");
             ViewBag.CourseList = CrsList;
         }
          [HttpPost]
        public ActionResult Course(CourseSetup aCourseSetup)
        {
            string Alart = _courseManager.SaveCourse(aCourseSetup);
            ViewBag.Message = Alart;
            DepartmentList();
            return View();
        }
	}
}