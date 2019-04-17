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
    /// Description : CivilStatus Entity Class
    /// Date of Creation : 10/19/2018
    /// </summary>
    /// 
    [MetadataType(typeof(Category))]
    public class CivilStatus
    {
        [Display(Name = "Status ID")]
        public int StatusId { get; set; }

        [Display(Name = "Status Description")]
        public string StatusDescription { get; set; }
    }
}
