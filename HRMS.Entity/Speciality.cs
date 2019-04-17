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
    /// Description : Speciality Entity Class
    /// Date of Creation : 10/19/2018
    /// </summary>
    [MetadataType(typeof(Speciality))]
    public class Speciality
    {
        [Display(Name = "Speciality ID")]
        public int SpecialityId { get; set; }

        [Display(Name = "Speciality Name")]
        public string SpecialityName { get; set; }
    }
}
