using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmplSchoolMange.BL.Interface;
using EmplSchoolMange.Models;
using EmplSchoolMange.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmplSchoolMange.Controllers
{
    public class EmployeeController : Controller
    {
        //Loosly Coupled
        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;
        private readonly ICountryRep country;
        private readonly ICityRep city;
        private readonly IDistrictRep district;
        //**** Dependancy Injection******
        public EmployeeController(IEmployeeRep employee, IDepartmentRep department, ICountryRep country, ICityRep city, IDistrictRep district)
        {
            this.employee = employee;
            this.department = department;
            this.country = country;
            this.city = city;
            this.district = district;
        }
        public IActionResult Index()
        {
            var data = employee.Get();
            return View(data);
        }

        public IActionResult Create()
        {
            var date = department.Get();
            var countrydate = country.Get();

            //SelectList ينفع نحط فيه فاليو تيكست  using Microsoft.AspNetCore.Mvc.Rendering;

            ViewBag.DepartmentList = new SelectList(date, "Id", "DepartmentName");
            ViewBag.CountryList = new SelectList(countrydate, "Id", "CountryName");
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
                var data = department.Get();
                ViewBag.DepartmentList = new SelectList(data , "Id", "DepartmentName");

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
            var Deptdata = department.Get();

            //ViewBag.DepartmentList = new SelectList(Deptdata, "Id", "DepartmentName",data.DepartmentId);

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
                var Deptdata = department.Get();
                ViewBag.DepartmentList = new SelectList(Deptdata, "Id", "DepartmentName", emp.DepartmentId);
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
            var Dptdata = department.Get();
            ViewBag.DepartmentList = new SelectList(Dptdata, "Id", "DepartmentName", data.DepartmentId);

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


        //---------------Ajax Call---------------
        public JsonResult GetCityDataByCountryId(int CntryID)
        {
            var data = city.Get().Where(a => a.CountryId == CntryID);
            return Json(data);
        }

        public JsonResult GetDistrictDataByCityId(int cityID)
        {
            var data = district.Get().Where(a => a.CityId == cityID);
            return Json(data);
        }

    }
}
