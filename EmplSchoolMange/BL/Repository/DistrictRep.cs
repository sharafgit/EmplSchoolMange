using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmplSchoolMange.BL.Interface;
using EmplSchoolMange.DAL.Database;
using EmplSchoolMange.Models;

namespace EmplSchoolMange.BL.Repository
{
    public class DistrictRep : IDistrictRep
    {
        private readonly DbContainer db;


        public DistrictRep(DbContainer db)
        {
            this.db = db;
        }

        public IQueryable<DistrictVM> Get()
        {
            IQueryable<DistrictVM> data = GetAllDistrict();
            return data;
        }


        public DistrictVM GetById(int id)
        {
            DistrictVM data = GetDistrictByID(id);
            return data;
        }



        // Refactor
        private DistrictVM GetDistrictByID(int id)
        {
            return db.District.Where(a => a.Id == id)
                                    .Select(a => new DistrictVM { Id = a.Id, DistrictName = a.DistrictName, CityId = a.CityId })
                                    .FirstOrDefault();
        }

        private IQueryable<DistrictVM> GetAllDistrict()
        {
            return db.District
                       .Select(a => new DistrictVM { Id = a.Id, DistrictName = a.DistrictName, CityId = a.CityId });
        }
    }
}
