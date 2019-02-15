using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCRMS.BLL;
using UCRMS.Models;

namespace UCRMS.Controllers
{
    public class AllocatedClassRoomController : Controller
    {
        private CourseSetupManager _CourseManager = new CourseSetupManager();
        private DepartmentManager _DepartmentManager = new DepartmentManager();
        private RoomAllocateManager _roomAllocateManager=new RoomAllocateManager();
        //
        // GET: /AllocatedClassRoom/
        [HttpGet]
        public ActionResult AllocatedClassRoom()
        {
            List<CourseSetup> CrsList = _CourseManager.GetAllCourseList("");
            ViewBag.SmList = new SelectList(CrsList, "ID", "Code");

            List<Department> dtpList = _DepartmentManager.GetShowDepartmentDetails();
            ViewBag.DpList = new SelectList(dtpList, "ID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult AllocatedClassRoom(RoomAllocate roomAllocate)
        {
            string Alart = _roomAllocateManager.SaveRoomAllocate(roomAllocate);
            ViewBag.Message = Alart;
            return View();
        }
	}
}