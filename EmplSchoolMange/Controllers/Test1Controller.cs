using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmplSchoolMange.Controllers
{
    public class Test1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //************Ajax Call**********
        [HttpPost]
        public JsonResult Display(string name) 
        {
            var data = "Welcome: " + name;
            return Json(data);
        }

    }
}
