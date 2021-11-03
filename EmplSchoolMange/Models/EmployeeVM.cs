using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmplSchoolMange.Models
{
    public class EmployeeVM
    {
        //Validations in Models
        //Add To Validations To Male sure Tha Data Is Correct
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter The Name Employee")]
        [MinLength(3, ErrorMessage = ("Min Len 3"))]
        [MaxLength(50, ErrorMessage = ("Max Len 50"))]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter The Salary Employee")]
        [Range(3000, 10000, ErrorMessage = ("Enter Salary From 3k to 10k"))]
        public float Salary { get; set; }
        [Required(ErrorMessage = "Enter The Adress Employee")]
        //[RegularExpression("[0-9]{2-5}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}", ErrorMessage =("10-StreetName-CityName-CountryName"))]
        public string Address { get; set; }
        public DateTime HirDate { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        // ForeignKey      
        public string DepartmentId { get; set; }
    }
}
