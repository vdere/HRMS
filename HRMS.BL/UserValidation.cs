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
    public class UserValidation
    {
        //Signup Code Validation 
        public static bool ValidateUser(Users newUser)
        {
            bool isValidUser = true;
            StringBuilder sbError = new StringBuilder();
            try
            {
                if (newUser.UserName == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter UserName");
                }
                if (newUser.Password == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("\nPlease Enter Password");
                }


                if (newUser.FirstName == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter First Name");
                }
                else if (!Regex.IsMatch(newUser.FirstName, "[A-Z][a-z]{2,}"))
                {
                    sbError.Append("First Name should start with Capital Alphabet, it should have minimum 3 characters and only alphabets\n");
                    isValidUser = false;
                }
                if (newUser.LastName == string.Empty)
                {
                    isValidUser = false;
                    sbError.Append("Please Enter Last Name");
                }
                else if (!Regex.IsMatch(newUser.LastName, "[A-Z][a-z]{2,}"))
                {
                    sbError.Append("Last Name should start with Capital Alphabet, it should have minimum 3 characters and only alphabets\n");
                    isValidUser = false;
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

        //LoginValidation Information
        public static bool ValidateLogin(Users newUser)
        {
            bool isValidLogin = true;
            StringBuilder sbError = new StringBuilder();
            try
            {
                if (newUser.UserName == string.Empty)
                {
                    isValidLogin = false;
                    sbError.Append("Please Enter Username");
                }
                if (newUser.Password == string.Empty)
                {
                    isValidLogin = false;
                    sbError.Append("\nPlease Enter Password");
                }
                if (!isValidLogin)
                    throw new HRMSException(sbError.ToString());
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return isValidLogin;
        }

        //Add User Validation Information
        public static int AddClerk_BLL(Users newUser)
        {
            int rowsAffected = 0;
            try
            {
                if (ValidateUser(newUser))
                {
                    rowsAffected = Users_DAL.AddClerk(newUser);
                }
                else
                    throw new HRMSException("\nPlease provide valid User Information");
            }
            catch (HRMSException ex) { throw ex; }
            catch (SqlException se) { throw se; }
            catch (SystemException ex) { throw ex; }
            return rowsAffected;

        }

        //Login HR/CLERK Information
        public static bool ClerkLogin(Users userLogin,string userName, string password, int roleId)
        {
            bool rowsAffected = false;
            try
            {
                if (ValidateLogin(userLogin))
                {
                    rowsAffected = Users_DAL.VerifyLogin(userName, password, roleId);
                }
                else
                    throw new Exception("\nPlease provide valid Login Details");
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return rowsAffected;
        }

        //Delete HR/CLERK Information
        public static int DeleteClerk_BLL(int userId)
        {
            int rowsAffected = 0;
            try
            {
                rowsAffected = Users_DAL.DeleteClerk(userId);
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return rowsAffected;
        }

        //Update HR/CLERK Information
        public static int UpdateClerk_BLL(Users user)
        {
            int rowsAffected = 0;
            try
            {
                if (ValidateUser(user))
                {
                    rowsAffected = Users_DAL.UpdateClerk(user);
                }
                else
                    throw new HRMSException("Please provide valid HR/Clerk Information");
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex) { throw ex; }
            return rowsAffected;
        }

        //Search HR/CLERK Information
        public static DataTable SearchClerk_BLL(int userId)
        {
            DataTable dtEmp;
            try
            {
                dtEmp = Users_DAL.SearchUserById(userId);
            }
            catch(HRMSException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtEmp;
        }

        //Display HR/Clerk Information
        public static DataTable DisplayClerk_BLL()
        {
            DataTable dtEmp;
            try
            {
                dtEmp = Users_DAL.DisplayUsers();
            }
            catch(HRMSException ex)
            {
                throw ex;
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtEmp;
        }
    }
}

