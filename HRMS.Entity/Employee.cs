using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Entity
{
    /// <summary>
    /// Employee ID :161585
    /// Employee Name : Viraj Dere
    /// Description : Employee Entity Class
    /// Date of Creation : 10/19/2018
    /// </summary>
    
    [MetadataType(typeof(Employee))]
    public class Employee
    {
        [Display(Name ="Employee ID")]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Civil Status")]
        public int CivilStatusId { get; set; }

        [Display(Name = "Religion")]
        public string Religion { get; set; }

        [Display(Name = "Citizenship")]
        public string Citizenship { get; set; }

        [Display(Name = "Mobile Number")]
        public long MobileNo { get; set; }

        [Display(Name = "Home Phone Number")]
        public long HomePhoneNo { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long Pincode { get; set; }
        public string Country { get; set; }

        [Display(Name = "Project ID")]
        public int Project_Id { get; set; }

        [Display(Name = "Skill ID")]
        public string SkillId { get; set; }

        [Display(Name = "Educational Background")]
        public string EducationalBackground { get; set; }
    }
}
