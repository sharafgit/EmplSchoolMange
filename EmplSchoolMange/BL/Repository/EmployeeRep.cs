using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmplSchoolMange.BL.Interface;
using EmplSchoolMange.DAL.Database;
using EmplSchoolMange.DAL.Entities;
using EmplSchoolMange.Models;

namespace EmplSchoolMange.BL.Repository
{
    public class EmployeeRep :IEmployeeRep
    {

        private readonly DbContainer db;
        private readonly IMapper mapper;

        //private DbContainer db= new DbContainer();
        public EmployeeRep(DbContainer db, IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }


        //Refeactorings*****Get==>GetAllDepts
        public IQueryable<EmployeeVM> Get()
        {
            IQueryable<EmployeeVM> data = GetAllEmps();
            return data;
        }



        //Refeactorings*****GetById==>GetDepartmentById
        public EmployeeVM GetById(int id)
        {
            EmployeeVM data = GetEmployeeById(id);
            return data;
        }


        public void Add(EmployeeVM emp)
        {
            //Mapping
            var data = mapper.Map<Employee>(emp);

            db.Employee.Add(data);
            db.SaveChanges();
        }

        public void Edit(EmployeeVM emp)
        {
            //Mapping
            var data = mapper.Map<Employee>(emp);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var DeleteObject = db.Employee.Find(id);
            db.Employee.Remove(DeleteObject);
            db.SaveChanges();
        }


        //Refeactorings
        private IQueryable<EmployeeVM> GetAllEmps()
        {
            return db.Employee
                .Select(a => new EmployeeVM{ Id = a.Id, Name=a.Name, Salary=a.Salary, Address=a.Address, Email=a.Email, HirDate=a.HirDate, IsActive=a.IsActive, Notes=a.Notes, DepartmentId = a.Department.DepartmentName });
        }
        private EmployeeVM GetEmployeeById(int id)
        {
            return db.Employee.Where(a => a.Id == id)
                                    .Select(a => new EmployeeVM{ Id = a.Id, Name = a.Name, Salary = a.Salary, Address = a.Address, Email = a.Email, HirDate = a.HirDate, IsActive = a.IsActive, Notes = a.Notes, DepartmentId = a.Department.DepartmentName })
                                    .FirstOrDefault();
        }
    }
}
