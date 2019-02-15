using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS.Models;

namespace UCRMS.Controllers
{
    public class ViewResultController : Controller
    {
        private CourseSetupManager _courseManager = new CourseSetupManager();
     
        //
        // GET: /ViewResult/   
           [HttpGet]
        public ActionResult ViewResult()
        {
            List<RegisterStudents> RegList = _courseManager.GetAllRegList("");
            ViewBag.CorShLst = new SelectList(RegList, "ID", "RegNo");

            return View();
        }
           public JsonResult GetStudentByDepartmentId(int departmentId)
           {
               var students = _courseManager.GetAllRegList("");

               return Json(students, JsonRequestBehavior.AllowGet);
           }

    }
}