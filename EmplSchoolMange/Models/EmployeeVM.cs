using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmplSchoolMange.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        [MaxLength(50, ErrorMessage = "Max Len 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Salary")]
        [Range(3000, 10000, ErrorMessage = "Enter Salary From 3K : 10K")]
        public float Salary { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}", ErrorMessage = "Enter Like 12-StreetName-CityName-CountryName")]
        public string Address { get; set; }

        public DateTime HireDate { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string Notes { get; set; }
        public int DepartmentId { get; set; }
        public int DistrictId { get; set; }
        public string DepartmentName { get; set; }
        public string DistrictName { get; set; }

    }
}
