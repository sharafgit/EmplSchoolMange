using EmplSchoolMange.BL.Interface;
using EmplSchoolMange.DAL.Database;
using EmplSchoolMange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmplSchoolMange.BL.Repository
{
    public class CityRep: ICityRep
    {
        private readonly DbContainer db;

        //private DbContainer db= new DbContainer();
        public CityRep(DbContainer db)
        {
            this.db = db;
        }


        //Refeactorings*****Get==>GetAllDepts
        public IQueryable<CityVM> Get()
        {
            IQueryable<CityVM> data = GetAllCityies();
            return data;
        }



        //Refeactorings*****GetById==>GetDepartmentById
        public CityVM GetById(int id)
        {
            CityVM data = GetCityById(id);
            return data;
        }

        //Refeactorings
        private IQueryable<CityVM> GetAllCityies()
        {
            return db.City
                .Select(a => new CityVM { Id = a.Id, CityName = a.CityName ,CountryId=a.Country.CountryName});
        }
        private CityVM GetCityById(int id)
        {
            return db.City
                .Where(a => a.Id == id)
                                    .Select(a => new CityVM { Id = a.Id, CityName = a.CityName, CountryId = a.Country.CountryName })
                                    .FirstOrDefault();
        }
    }
}
