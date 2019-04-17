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
    /// Description : Project Entity Class
    /// Date of Creation : 10/19/2018
    /// </summary>
    /// 
    [MetadataType(typeof(Project))]
    public class Project
    {
        [Display(Name = "Project ID")]
        public int ProjectId { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Display(Name = "Project Description")]
        public string ProjectDescription { get; set; }

        [Display(Name = "Project Client")]
        public string ProjectClient { get; set; }

        [Display(Name = "Project Start Date")]
        public DateTime ProjectStartDate { get; set; }

        [Display(Name = "Project End Date")]
        public DateTime ProjectEndDate { get; set; }
    }
}
