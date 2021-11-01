using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmplSchoolMange.Models;

namespace EmplSchoolMange.BL.Interface
{
   public interface IDepartmentRep
    {
        IQueryable<DepartmentVM> Get();
        DepartmentVM GetById(int id);

        //use to void because add do not return data just send data only
        void Add(DepartmentVM emp);
        void Edit(DepartmentVM emp);
        void Delete(int id);

    }
}
