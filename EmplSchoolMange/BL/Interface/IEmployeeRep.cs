using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmplSchoolMange.Models;

namespace EmplSchoolMange.BL.Interface
{
    public interface IEmployeeRep
    {
        IQueryable<EmployeeVM> Get();
        EmployeeVM GetById(int id);

        //use to void because add do not return data just send data only
        void Add(EmployeeVM dpt);
        void Edit(EmployeeVM dpt);
        void Delete(int id);
    }
}
