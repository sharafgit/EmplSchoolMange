using EmplSchoolMange.BL.Interface;
using EmplSchoolMange.DAL.Database;
using EmplSchoolMange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmplSchoolMange.BL.Repository
{
    public class CountryRep : ICountryRep
    {
        private readonly DbContainer db;

        //private DbContainer db= new DbContainer();
        public CountryRep(DbContainer db)
        {
            this.db = db;
        }


        //Refeactorings*****Get==>GetAllDepts
        public IQueryable<CountryVM> Get()
        {
            IQueryable<CountryVM> data = GetAllCountries();
            return data;
        }



        //Refeactorings*****GetById==>GetDepartmentById
        public CountryVM GetById(int id)
        {
            CountryVM data = GetCountryById(id);
            return data;
        }

        //Refeactorings
        private IQueryable<CountryVM> GetAllCountries()
        {
            return db.Country
                .Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName});
        }
        private CountryVM GetCountryById(int id)
        {
            return db.Country.Where(a => a.Id == id)
                                    .Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName})
                                    .FirstOrDefault();
        }

    }
}
