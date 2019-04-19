using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entity;
using HRMS.DAL;
using System.Data;

namespace HRMS.DAL
{
    /// <summary>
    /// Employee ID :161585
    /// Employee Name : Viraj Dere
    /// Description : Handles User(HR Clerk/Manager) Specific operations
    /// Date of Creation : 10/23/2018
    /// </summary>
    public class Users_DAL
    {
        //Method to Add HR Clerk/Manager to Database
        public static int AddClerk(Users user)
        {
            int rowsAffected = 0;
            try
            {
                //Creating command object
                SqlCommand empCommand = DataConnections.GenerateCommand();

                //Assigning command text
                empCommand.CommandText = "Group4.usp_AddUser";

                //Adding parameters to command
                empCommand.Parameters.AddWithValue("@UserName",user.UserName);
                empCommand.Parameters.AddWithValue("@Password_", user.Password);
                empCommand.Parameters.AddWithValue("@First_Name", user.FirstName);
                empCommand.Parameters.AddWithValue("@Last_Name", user.LastName);

                //Executing command
                empCommand.Connection.Open();
                rowsAffected = empCommand.ExecuteNonQuery();
                empCommand.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowsAffected;
        }

        //Method to Delete HR Clerk/Manager From Database
        public static int DeleteClerk(int userId)
        {
            int rowsAffected = 0;
            try
            {
                //Creating command object
                SqlCommand empCommand = DataConnections.GenerateCommand();
                //Assigning command text

                empCommand.CommandText = "Group4.usp_DeleteUser";
                empCommand.Parameters.AddWithValue("@userId", userId);

                empCommand.Connection.Open();
                rowsAffected = empCommand.ExecuteNonQuery();
                empCommand.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowsAffected;

        }

        //Method to Modify HR Clerk/Manager From Database
        public static int UpdateClerk(Users user)
        {
            int rowsAffected = 0;
            try
            {
                //Creating command object
                SqlCommand empCommand = DataConnections.GenerateCommand();
                //Assigning command text

                empCommand.CommandText = "Group4.usp_UpdateUser";
                empCommand.Parameters.AddWithValue("@UserId", user.UserId);
                empCommand.Parameters.AddWithValue("@UserName", user.UserName);
                empCommand.Parameters.AddWithValue("@Password_", user.Password);
                empCommand.Parameters.AddWithValue("@First_Name", user.FirstName);
                empCommand.Parameters.AddWithValue("@Last_Name", user.LastName);
                empCommand.Connection.Open();
                rowsAffected = empCommand.ExecuteNonQuery();
                empCommand.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowsAffected;
        }

        //Method to Display HR Clerk/Manager From Database
        public static DataTable DisplayUsers()
        {
            DataTable dtEmp;
            SqlDataReader empReader = null;
            try
            {
                //Creating command object
                SqlCommand empCommand = DataConnections.GenerateCommand();

                dtEmp = new DataTable();
                empCommand.CommandText = "Group4.usp_DisplayAllUsers";
                empCommand.Connection.Open();
                empReader = empCommand.ExecuteReader();
                if (empReader.HasRows)
                {
                    dtEmp.Load(empReader);
                }
                empReader.Close();
                empCommand.Connection.Close();
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

        //Method to Verify HR Clerk/Manager Login From Database
        public static bool VerifyLogin(string userName, string password, int roleId)
        {
            bool rowsAffected = false;
            SqlDataReader empReader = null;
            try
            {
                //Creating command object
                SqlCommand empCommand = DataConnections.GenerateCommand();
                empCommand.CommandText = "Group4.VerifyLogin";

                empCommand.Parameters.AddWithValue("@UserName", userName);
                empCommand.Parameters.AddWithValue("@pass", password);
                empCommand.Parameters.AddWithValue("@rId", roleId);
                empCommand.Connection.Open();
                empReader = empCommand.ExecuteReader();
                if (empReader.HasRows)
                {
                    empReader.Read();
                    if (userName == empReader["UserName"].ToString() && password == empReader["Password_"].ToString())
                        rowsAffected = true;
                }
                empReader.Close();
                empCommand.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowsAffected;
        }

        //Method to Search HR Clerk/Manager From Database
        public static DataTable SearchUserById(int userId)
        {
            DataTable dtEmp;
            SqlDataReader empReader = null;
            try
            {
                //Creating command object
                SqlCommand empCommand = DataConnections.GenerateCommand();

                dtEmp = new DataTable(/*int EmpId*/);
                empCommand.CommandText = "Group4.usp_SearchUser";
                empCommand.Parameters.AddWithValue("@UserId", userId);
                empCommand.Connection.Open();
                empReader = empCommand.ExecuteReader();
                if (empReader.HasRows)
                {
                    dtEmp.Load(empReader);
                }
                empReader.Close();
                empCommand.Connection.Close();
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

        //Method to load Role of user during login
        public static DataTable LoadUserRoles()
        {
            DataTable dtDept;
            SqlDataReader empReader = null;
            try
            {
                //Creating command object
                SqlCommand empCommand = DataConnections.GenerateCommand();

                dtDept = new DataTable();
                empCommand.CommandText = "Group4.usp_DisplayUserRole";
                empCommand.Connection.Open();
                empReader = empCommand.ExecuteReader();
                dtDept.Load(empReader);
                empReader.Close();
                empCommand.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtDept;
        }

    }
}
