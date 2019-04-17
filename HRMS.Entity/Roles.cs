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
    /// Description : Roles Entity Class
    /// Date of Creation : 10/19/2018
    /// </summary>
    /// 
    [MetadataType(typeof(Roles))]
    public class Roles
    {
        [Display(Name = "Role ID")]
        public int RoleId { get; set; }

        [Display(Name = "Role Names")]
        public string RoleName { get; set; }
    }
}
