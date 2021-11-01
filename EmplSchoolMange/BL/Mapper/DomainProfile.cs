using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmplSchoolMange.DAL.Entities;
using EmplSchoolMange.Models;

namespace EmplSchoolMange.BL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            //Department
            CreateMap<Department, DepartmentVM>(); 
            CreateMap<DepartmentVM, Department>();

            //Employee
            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();
        }
    }
}
