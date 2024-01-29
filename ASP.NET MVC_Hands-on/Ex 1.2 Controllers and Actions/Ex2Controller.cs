using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP_App1.Controllers
{
    public class Ex2Controller : Controller
    {
        // Implement 'Course' action
        public ActionResult Course(int id)
        {
            if (id == 1)
            {
                return RedirectToAction("JavaCourse");
            }
            else if (id == 2)
            {
                return RedirectToAction("DotNetCourse");
            }
            else
            {
                // Handle invalid course id
                return RedirectToAction("Index", "Home");
            }
        }

        // Implement 'JavaCourse' action
        public ActionResult JavaCourse()
        {
            return Content("JavaCourse");
        }

        // Implement 'DotNetCourse' action
        public ActionResult DotNetCourse()
        {
            return Content("DotNetCourse");
        }
    }
}