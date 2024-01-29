using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_App1.Controllers               //DO NOT change the namespace name
{
    public class Ex1Controller : Controller  //DO NOT change the class name
    {
        List<String> breakingNews = new List<String>()      //DO NOT change this declaration and values
        {
            "PM visit brings business","10% slash in GST","Top Player announced retirement","India wins series"
        };

        // Implement 'NewsByChoice' action  
        public ActionResult NewsByChoice(int id)
        {
            if (id >= 1 && id <= breakingNews.Count)
            {
                string selectedNews = breakingNews[id - 1];
                return Content(selectedNews);
            }
            else
            {
                return Content("Invalid news choice.");
            }
        }
        
        // Implement 'AllNews' action
        public ActionResult AllNews()
        {
            string allNews = string.Join("\n", breakingNews);
            return Content(allNews);
        }
        
    }
}