using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entity;
using HRMS.Exceptions;
using HRMS.DAL;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace HRMS.BL
{
    /// <summary>
    /// Employee ID :161611
    /// Employee Name : Mansih
    /// Description : Validate Employee and call employee  operations methods in DAL
    /// Date of Creation : 01/11/2018
    /// </summary>
    public class EmployeeValidation
    {
        //Validation of Details
        public static bool ValidatEmployee(Employee newEmp)
        {

            bool isValidUser = true;
            StringBuilder sbError = new StringBuilder();
            try
            {
                if (newEmp.FirstName == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter FirstName");
                }
                else if (!Regex.IsMatch(newEmp.FirstName, "[A-Z][a-z]{2,}"))
                {
                    sbError.Append("Employee first Name should start with Capital Alphabet, it should have minimum 3 characters and only alphabets\n");
                    isValidUser = false;
                }
                if (newEmp.MiddleName == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter MiddleName");
                }
                else if (!Regex.IsMatch(newEmp.MiddleName, "[A-Z][a-z]{2,}"))
                {
                    sbError.Append("Employee Middle Name should start with Capital Alphabet, it should have minimum 3 characters and only alphabets\n");
                    isValidUser = false;
                }
                if (newEmp.LastName == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter LastName");
                }
                else if (!Regex.IsMatch(newEmp.LastName, "[A-Z][a-z]{2,}"))
                {
                    sbError.Append("Employee Last Name should start with Capital Alphabet, it should have minimum 3 characters and only alphabets\n");
                    isValidUser = false;
                }
                int age = DateTime.Now.Year - newEmp.BirthDate.Year;
                if (age < 18)
                {
                    sbError.Append("Date of Birth should be proper so that Employee age will be > 18\n");
                    isValidUser = false;
                }
                if (newEmp.Age < 18)
                {
                    sbError.Append("Employee Age Should be 18 or 18+\n");
                    isValidUser = false;
                }
                if (newEmp.Gender == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Select Gender");
                }
                if (newEmp.CivilStatusId.ToString() == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please select CivilStatus ");
                }
                if (newEmp.Religion == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter Religion ");
                }
                if (newEmp.Citizenship == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter Citizenship ");
                }

                if (newEmp.MobileNo.ToString() == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter mobile no");
                }
                if (!Regex.IsMatch(Convert.ToString(newEmp.MobileNo), "[0-9]{10}"))
                {
                    sbError.Append("Mobile number should have exactly 10 digits\n");
                    isValidUser = false;
                }

                if (newEmp.HomePhoneNo.ToString() == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter Home Phone no");
                }
                if (!Regex.IsMatch(Convert.ToString(newEmp.HomePhoneNo), "[0-9]{10}"))
                {
                    sbError.Append("Home Phone number should have exactly 10 digits\n");
                    isValidUser = false;
                }
                if (newEmp.Address == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter Address");
                }
                if (newEmp.City == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter City");
                }

                if (newEmp.State == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter State");
                }

                if (newEmp.Pincode.ToString() == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter LastName");
                }
                if (!Regex.IsMatch(Convert.ToString(newEmp.Pincode), "[0-9]{6}"))
                {
                    isValidUser = false;
                    sbError.Append("Please Enter pincode exactly 6 digit long");
                }
                if (newEmp.Country == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter Country");
                }

                if (newEmp.Project_Id.ToString() == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Select Project");
                }
                if (newEmp.SkillId == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Select Project");
                }
                if (newEmp.EducationalBackground == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter EducationalBackground");
                }
                if (!isValidUser)
                    throw new HRMSException(sbError.ToString());
            }
            catch (HRMSException ex)
            {
                throw ex;
            }

            return isValidUser;
        }

        //Calling Add Employee
        public static int AddEmployee_BL(Employee newEmp,CapgeminiDetails capg)
        {
            int rowsAffected = 0;
            try
            {
                if (ValidatEmployee(newEmp))
                {
                    rowsAffected = Employee_DAL.AddEmployee(newEmp, capg);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return rowsAffected;
        }

        //Calling Update Employee
        public static int UpdateEmployee_BL(Employee newEmp,CapgeminiDetails capg)
        {
            int rowsAffected = 0;
            try
            {
                if (ValidatEmployee(newEmp))
                {
                    rowsAffected = Employee_DAL.UpdateEmployee(newEmp,capg);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return rowsAffected;
        }

        //Get Autogenerated ID
        public static int GetAutogeneratedEmployeeID_BL()
        {
            int Empid = 0;
            try
            {

                Empid = Employee_DAL.GetAutoGeneratedEmployeeId();


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return Empid;
        }

        //Delete Employee
        public static int DeleteEmployee_BL(int id)
        {
            int rowsAffected = 0;
            try
            {


                rowsAffected = Employee_DAL.DeleteEmployee(id);



            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return rowsAffected;
        }

        //Search Employee By Id
        public static DataTable SearchEmployeeById_BL(int id)
        {
            DataTable Emp = null;
            try
            {


                Emp = Employee_DAL.SearchEmployeeById(id);



            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return Emp;
        }

        //Dispaly All EMployee
        public static DataTable DisplayEmployee_BL()
        {
            DataTable Emp = null;
            try
            {
                Emp = Employee_DAL.DisplayAllEmployees();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return Emp;
        }

        public static DataTable LoadCivilStatus_BL()
        {
            DataTable CVS = null;
            try
            {


                CVS = Employee_DAL.LoadCivilStatus();



            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return CVS;
        }

        //Load All Project
        public static DataTable LoadProject_BL()
        {
            DataTable Project = null;
            try
            {


                Project = Employee_DAL.LoadProjectNames();



            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return Project;
        }

        //Load All Skill
        public static DataTable LoadSkill_BL()
        {
            DataTable skill = null;
            try
            {

                skill = Employee_DAL.LoadSkills();


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return skill;
        }

        //Load All Level
        public static DataTable LoadLevel_BL()
        {
            DataTable level = null;
            try
            {


                level = Employee_DAL.LoadLevels();



            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return level;
        }

        //Load All Seciality
        public static DataTable LoadSeciality_BL()
        {
            DataTable Spec = null;
            try
            {


                Spec = Employee_DAL.LoadSpeciality();



            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return Spec;
        }
    }
}
