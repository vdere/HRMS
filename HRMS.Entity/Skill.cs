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
    /// Description : Skill Entity Class
    /// Date of Creation : 10/19/2018
    /// </summary>
    [MetadataType(typeof(Skill))]
    public class Skill
    {
        public int SkillId { get; set; }

        [Display(Name = "Skill Name")]
        public string SkillName { get; set; }

        [Display(Name = "Skill Description")]
        public string SkillDescription { get; set; }

        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
    }
}
