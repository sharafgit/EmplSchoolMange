using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmplSchoolMange.BL.Repository;
using EmplSchoolMange.DAL.Database;
using EmplSchoolMange.Models;
using System.Diagnostics;
using EmplSchoolMange.BL.Interface;

namespace EmplSchoolMange.Controllers
{
    
    public class DepartmentController : Controller
    {
        #region Dependancy Injection
        //Loosly Coupled
        private readonly IDepartmentRep department;

        // Tighly Coupled
        //**** Dependancy Injection******
        // private readonly DepartmentRep department;
        public DepartmentController(IDepartmentRep department)
        {
            this.department = department;
        } 
        #endregion


        public IActionResult Index()
        {

            #region SendData
            // view Data == > Object
            //ViewData["x"] = "Hi Im view Data";

            // View Bag
            // ViewBag.y = "Hi Im view Bag";

            // Temp Data
            // TempData["z"] = "Hi Im Temp Data";

            //string[] arr = { "Ahmed", "baaa", "caaaa", "daaa" };
            // ViewBag.data=arr;
            #endregion

            //DepartmentVM dpt1 = new DepartmentVM() { Id = 1, DepartmentName = "Ahmed", DepartmentCode = "A100" };
            //DepartmentVM dpt2 = new DepartmentVM() { Id = 2, DepartmentName = "Mohamed", DepartmentCode = "A200" };
            //DepartmentVM dpt3 = new DepartmentVM() { Id = 3, DepartmentName = "Ali", DepartmentCode = "A300" };
            //List<DepartmentVM> DptData = new List<DepartmentVM>();
            //DptData.Add(dpt1); 
            //DptData.Add(dpt2); 
            //DptData.Add(dpt3);
            ////ViewBag.data = DptData;

            // ربط الداتا LU SD;,G UK 'VDR 
            //var data = db.Department.Select(a =>  new DepartmentVM {Id=a.Id , DepartmentName=a.DepartmentName , DepartmentCode =a.DepartmentCode});


            var data = department.Get();
            return View(data);
            //return RedirectToAction("Index", "Home"); 

        }




        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Add(dpt);
                    return RedirectToAction("Index", "Department");
                }return View(dpt);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashbord";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(dpt);
            }
            
            
        }


        public IActionResult Edit(int id)
        {
            var data = department.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Edit(dpt);
                    return RedirectToAction("Index", "Department");
                }
                return View(dpt);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashbord";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(dpt);
            }
        }


        public IActionResult Delete(int id)
        {
            var data = department.GetById(id);
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
                    department.Delete(id);
                    return RedirectToAction("Index", "Department");
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
