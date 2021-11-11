using EmplSchoolMange.BL.Interface;
using EmplSchoolMange.DAL.Database;
using EmplSchoolMange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmplSchoolMange.BL.Repository
{
    public class DistrictRep: IDistrictRep
    {
        private readonly DbContainer db;

        //private DbContainer db= new DbContainer();
        public DistrictRep(DbContainer db)
        {
            this.db = db;
        }

        //Refeactorings*****Get==>GetAllDepts
        public IQueryable<DistrictVM> Get()
        {
            IQueryable<DistrictVM> data = GetAllDistricties();
            return data;
        }


        //Refeactorings*****GetById==>GetDepartmentById
        public DistrictVM GetById(int id)
        {
            DistrictVM data = GetDistrictById(id);
            return data;
        }

        //Refeactorings
        private IQueryable<DistrictVM> GetAllDistricties()
        {
            return db.District
                .Select(a => new DistrictVM { Id = a.Id, DistrictName = a.DistrictName, CityId = a.City.CityName });
        }
        private DistrictVM GetDistrictById(int id)
        {
            return db.District
                .Where(a => a.Id == id)
                                    .Select(a => new DistrictVM { Id = a.Id, DistrictName = a.DistrictName, CityId = a.City.CityName })
                                    .FirstOrDefault();
        }
    }
}
