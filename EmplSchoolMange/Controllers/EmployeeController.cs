using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmplSchoolMange.BL.Interface;
using EmplSchoolMange.Models;
using EmplSchoolMange.DAL.Entities;

namespace EmplSchoolMange.Controllers
{
    public class EmployeeController : Controller
    {
        //Loosly Coupled
        private readonly IEmployeeRep employee;
        //**** Dependancy Injection******
        public EmployeeController(IEmployeeRep employee)
        {
            this.employee = employee;
        }
        public IActionResult Index()
        {
            var data = employee.Get();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employee.Add(emp);
                    return RedirectToAction("Index", "Employee");
                }
                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashbord";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }


        }


        public IActionResult Edit(int id)
        {
            var data = employee.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employee.Edit(emp);
                    return RedirectToAction("Index", "Employee");
                }
                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashbord";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }
        }


        public IActionResult Delete(int id)
        {
            var data = employee.GetById(id);
            //if (data==null)
            //{

            //}
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                employee.Delete(id);
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashbord";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }
        }
    }
}
