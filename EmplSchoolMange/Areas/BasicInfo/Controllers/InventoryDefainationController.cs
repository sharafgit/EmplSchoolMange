using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmplSchoolMange.Areas.BasicInfo.Controllers
{
    [Area("BasicInfo")]
    public class InventoryDefainationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
