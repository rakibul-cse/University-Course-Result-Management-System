using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS.BLL;
using UCRMS.Models;

namespace UCRMS.Controllers
{
    public class StudentResultController : Controller
    {
        private CourseSetupManager _courseManager = new CourseSetupManager();
        private StudentResultManager _studentResultManager=new StudentResultManager();
        //
        // GET: /StudentResult/
        [HttpGet]
        public ActionResult StudentResult()
        {
            GetAllRessult();
            return View();
        }

        public void GetAllRessult()
        {
            try
            {
                List<CourseSetup> CrsList = _courseManager.GetAllCourseList("");
                ViewBag.SmList = new SelectList(CrsList, "ID", "Code");

                List<RegisterStudents> RegList = _courseManager.GetAllRegList("");
                ViewBag.CorShLst = new SelectList(RegList, "ID", "RegNo");

                List<StudentResults> ResultList = _studentResultManager.GetAllResultGradet("");
                ViewBag.RsltLst = new SelectList(ResultList, "ID", "Grade");
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
           
            
        }
         [HttpPost]
        public ActionResult StudentResult(StudentResults studentResults)
         {
             try
             {
                 string Alart = _studentResultManager.SaveStudentResult(studentResults);
                 ViewBag.Message = Alart;
                 GetAllRessult();
                 return View();
             }
             catch (Exception ex)
             {
                 
                     throw new Exception(ex.Message);
             }
             
        }

         public JsonResult GetStudentByStudent(int ResistrationNO)
         {
             var students = _courseManager.GetAllRegList(ResistrationNO.ToString());
             return Json(students, JsonRequestBehavior.AllowGet);
         }
    }
}