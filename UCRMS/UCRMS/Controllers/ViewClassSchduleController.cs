using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UCRMS.Controllers
{
    public class ViewClassSchduleController : Controller
    {
        private DepartmentManager _DepartmentManager = new DepartmentManager();
        //
        // GET: /ViewClassSchdule/
        [HttpGet]
        public ActionResult ViewClassSchdule()
        {

            List<Department> dtpList = _DepartmentManager.GetShowDepartmentDetails();
            ViewBag.DpList = new SelectList(dtpList, "ID", "Name");

            return View();
        }
	}
}