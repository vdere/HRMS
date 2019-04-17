using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity
{
    /// <summary>
    /// Employee ID :161585
    /// Employee Name : Viraj Dere
    /// Description : CapgeminiDetails Entity Class
    /// Date of Creation : 10/19/2018
    /// </summary>
    /// 
    [MetadataType(typeof(CapgeminiDetails))]
    public class CapgeminiDetails
    {
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        [Display(Name = "Email ID")]
        public string Email { get; set; }

        [Display(Name = "Level ID")]
        public int LevelId { get; set; }

        [Display(Name = "Date Hired")]
        public DateTime DateHired { get; set; }

        [Display(Name = "Speciality ID")]
        public int SpecialityId { get; set; }

        

    }
}
