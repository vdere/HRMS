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
    /// Description : Level Entity Class
    /// Date of Creation : 10/19/2018
    /// </summary>
    /// 
    [MetadataType(typeof(Category))]
    public class Level
    {
        [Display(Name = "Level ID")]
        public int LevelId { get; set; }

        [Display(Name = "Level Description")]
        public string LevelDescription { get; set; }
    }
}
