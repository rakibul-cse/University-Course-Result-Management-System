using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UCRMS.Controllers
{
    
    public class DepartmentController : Controller
    {
        private DepartmentManager _DepartmentManager = new DepartmentManager();
        //
        // GET: /Department/
        [HttpGet]
        public ActionResult Department()
        {
            DepartmentList();
            return View();
        }

        private void DepartmentList()
        {
            List<Department> dtpList = _DepartmentManager.GetShowDepartmentDetails();
            ViewBag.DpList = dtpList;
        }

        [HttpPost]
        public ActionResult Department(Department aDepartment)
        {
            string Alert = _DepartmentManager.SaveDepartment(aDepartment);
            DepartmentList();
            ViewBag.Message=Alert;           
            return View();
        }
	}
}