using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmplSchoolMange.Models
{
    public class DistrictVM
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int CityId { get; set; }
    }
}
