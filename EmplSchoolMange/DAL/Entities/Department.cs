using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmplSchoolMange.DAL.Entities
{
    [Table("Department")]
    public class Department
    {
        //Validations in Entities
        //About Configuration Column In The Table
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        // ForeignKey      
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
