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
    public class DepartmentRep : IDepartmentRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        //private DbContainer db= new DbContainer();
        public DepartmentRep(DbContainer db ,IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }


        //Refeactorings*****Get==>GetAllDepts
        public IQueryable<DepartmentVM> Get()
        {
            IQueryable<DepartmentVM> data = GetAllDepts();
            return data;
        }

       

        //Refeactorings*****GetById==>GetDepartmentById
        public DepartmentVM GetById(int id)
        {
            DepartmentVM data = GetDepartmentById(id);
            return data;
        }
       

        public void Add(DepartmentVM dpt)
        {
            //Mapping
            //Department d = new Department();
            //d.DepartmentName = dpt.DepartmentName;
            //d.DepartmentCode = dpt.DepartmentCode;
            //Mapping
            var data = mapper.Map<Department>(dpt);

            db.Department.Add(data);
            db.SaveChanges();
        }

        public void Edit(DepartmentVM dpt)
        {
            //var OldData = db.Department.Find(dpt.Id);
            //Replase
            //OldData.DepartmentName = dpt.DepartmentName;
            //OldData.DepartmentCode = dpt.DepartmentCode;
            
            //Mapping
            var data = mapper.Map<Department>(dpt);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var DeleteObject = db.Department.Find(id);
            db.Department.Remove(DeleteObject);
            db.SaveChanges();
        }


        //Refeactorings
        private IQueryable<DepartmentVM> GetAllDepts()
        {
            return db.Department
                .Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode });
        }
        private DepartmentVM GetDepartmentById(int id)
        {
            return db.Department.Where(a => a.Id == id)
                                    .Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode })
                                    .FirstOrDefault();
        }
    }
}
