using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmplSchoolMange.BL.Interface;
using EmplSchoolMange.Models;
using EmplSchoolMange.Resource;

namespace EmplSchoolMange.Controllers
{
    public class EmployeeController : Controller
    {

        // Loosly Coupled
        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;
        private readonly ICountryRep country;
        private readonly ICityRep city;
        private readonly IDistrictRep district;
        //private readonly IStringLocalizer<SharedResource> sharedLocalizer;

        // Dependency Injection
        public EmployeeController(IEmployeeRep employee, IDepartmentRep department, ICountryRep country, ICityRep city, IDistrictRep district)
        {
            this.employee = employee;
            this.department = department;
            this.country = country;
            this.city = city;
            this.district = district;
            //sharedLocalizer = SharedLocalizer;
        }

        public IActionResult Index(int PageIndex, int PageSize)
        {

            //var data = employee.Get().Skip(3).Take(3);
            var data = employee.Get();

            return View(data);
        }

        public IActionResult Details(int id)
        {
            var data = employee.GetById(id);
            var Dptdata = department.Get();
            var countrydata = country.Get();
            //SelectList ينفع نحط فيه فاليو تيكست  using Microsoft.AspNetCore.Mvc.Rendering;

            ViewBag.DepartmentList = new SelectList(Dptdata, "Id", "DepartmentName", data.DepartmentId);
            ViewBag.CountryList = new SelectList(countrydata, "Id", "CountryName", data.DistrictId);

            return View(data);
        }
        public IActionResult Create()
        {
            var data = department.Get();
            var countrydata = country.Get();

            ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");
            ViewBag.CountryList = new SelectList(countrydata, "Id", "CountryName");

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

                ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");
                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }


        }

        public IActionResult Edit(int id)
        {
            var data = employee.GetById(id);

            var Deptdata = department.Get();

            ViewBag.DepartmentList = new SelectList(Deptdata, "Id", "DepartmentName", data.DepartmentId);
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
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }
        }


        public IActionResult Delete(int id)
        {
            var data = employee.GetById(id);
            //if(data == null)
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
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }
        }



        // --------------------- Ajax Call -----------------------

        [HttpPost]
        public JsonResult GetCityDataByCountryId(int CntryID)
        {
            var data = city.Get().Where(a => a.CountryId == CntryID);
            return Json(data);
        }


        [HttpPost]
        public JsonResult GetDistrictDataByCityId(int cityId)
        {
            var data = district.Get().Where(a => a.CityId == cityId);
            return Json(data);
        }






        //public IActionResult Arabic()
        //{
        //    return Redirect(Request.UrlRefer)
        //}






    }
}
