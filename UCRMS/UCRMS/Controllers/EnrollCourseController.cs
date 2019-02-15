using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS.BLL;
using UCRMS.Models;

namespace UCRMS.Controllers
{
    public class EnrollCourseController : Controller
    {
        private CourseSetupManager  _courseManager=new CourseSetupManager();
        private EnrollCourseManager _enrollCourseManager=new EnrollCourseManager();
        //
        // GET: /EnrollCourse/
        [HttpGet]
        public ActionResult EnrollCourse()
        {
            GetAllDetail();
            return View();
        } 
        private void GetAllDetail()
        {
            List<CourseSetup> CrsList = _courseManager.GetAllCourseList("");
            ViewBag.SmList = new SelectList(CrsList, "ID", "Code");

            List<RegisterStudents> RegList = _courseManager.GetAllRegList("");
            ViewBag.CorShLst = new SelectList(RegList, "ID", "RegNo");
        }
            [HttpPost]
        public ActionResult EnrollCourse(EnrollCourses enrollCourses )
        {
            try
            {
                string Alart = _enrollCourseManager.SaveCourseEnroll(enrollCourses);
                ViewBag.Message = Alart;
                GetAllDetail();
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
            //public JsonResult GetStudentByDepartmentId(int RegNo)
            //{
            //    var students = _courseManager.GetAllRegList("");
            //    var selectedStudents = students
            //        .Where(c => c.RegNo == RegNo.ToString())
            //        .ToList()
            //        .Select(c => new
            //        {
            //            c.Name,
            //            c.Email,
            //            c.DeptID,
            //            c.RegNo
            //        }).ToList();
            //    return Json(selectedStudents, JsonRequestBehavior.AllowGet);
            //}
    }
}