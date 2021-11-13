using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmplSchoolMange.BL.Service
{
    public class EmployeeServiceController : Controller
    {
        [Route("/EmployeeService/GitCity")]
        public IActionResult GitCity()
        {
            return Json("");
        }
    }
}
