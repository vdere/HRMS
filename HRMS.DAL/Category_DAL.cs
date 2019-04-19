﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entity;
using System.Data;

namespace HRMS.DAL
{
    /// <summary>
    /// Employee ID :161585
    /// Employee Name : Viraj Dere
    /// Description : Handles Employee-Category Specific operations
    /// Date of Creation : 10/23/2018
    /// </summary>
    public class Category_DAL
    {
        //Function to get autogenerated Category Id
        public static int GetAutoGeneratedCategoryId()
        {
            int newCategoryId;
            try
            {
                SqlConnection connObj = new SqlConnection(@"Data Source=ndamssql\sqlilearn;Initial Catalog=Sep19CHN;User ID=sqluser;Password=sqluser");
                SqlCommand cmdObj = new SqlCommand("select IDENT_CURRENT('Group4.Category')+ident_incr('Group4.Category')", connObj);
                connObj.Open();
                object objResult = cmdObj.ExecuteScalar();
                newCategoryId = Convert.ToInt32(objResult);
                connObj.Close();// return single data - obj
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newCategoryId;

        }

        //Method to Add Category to Database
        public static int AddCategory(Category newCat)
        {
            int rowsAffected = 0;
            try
            {
                //Creating command object
                SqlCommand catCommand = DataConnections.GenerateCommand();

                //Assigning command text
                catCommand.CommandText = "Group4.usp_AddCategory";

                //Adding parameters to command
                catCommand.Parameters.AddWithValue("@Category_Name", newCat.CategoryName);
                catCommand.Parameters.AddWithValue("@Category_Description", newCat.CategoryDescription);

                //Executing command
                catCommand.Connection.Open();
                rowsAffected = catCommand.ExecuteNonQuery();
                catCommand.Connection.Close();
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

        //Method to Delete Category From Database
        public static int DeleteCategory(int catId)
        {
            int rowsAffected = 0;
            try
            {
                //Creating command object
                SqlCommand catCommand = DataConnections.GenerateCommand();
                //Assigning command text

                catCommand.CommandText = "Group4.usp_DeleteCategory";
                catCommand.Parameters.AddWithValue("@Category_Id", catId);

                catCommand.Connection.Open();
                rowsAffected = catCommand.ExecuteNonQuery();
                catCommand.Connection.Close();
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

        //Method to Modify Category From Database
        public static int UpdateCategory(Category newCat)
        {
            int rowsAffected = 0;
            try
            {
                //Creating command object
                SqlCommand catCommand = DataConnections.GenerateCommand();
                //Assigning command text

                catCommand.CommandText = "Group4.usp_UpdateCategory";
                catCommand.Parameters.AddWithValue("@Category_Id", newCat.CategoryId);
                catCommand.Parameters.AddWithValue("@Category_Name", newCat.CategoryName);
                catCommand.Parameters.AddWithValue("@Category_Description", newCat.CategoryDescription);

                catCommand.Connection.Open();
                rowsAffected = catCommand.ExecuteNonQuery();
                catCommand.Connection.Close();
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

        //Method to Display Category From Database
        public static DataTable DisplayAllCategories()
        {
            DataTable dtProj;
            SqlDataReader catReader = null;
            try
            {
                //Creating command object
                SqlCommand catCommand = DataConnections.GenerateCommand();

                dtProj = new DataTable();
                catCommand.CommandText = "Group4.usp_DisplayAllCategories";
                catCommand.Connection.Open();
                catReader = catCommand.ExecuteReader();
                if (catReader.HasRows)
                {
                    dtProj.Load(catReader);
                }
                catReader.Close();
                catCommand.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtProj;
        }

        //Method to Search Category From Database
        public static DataTable SearchCategoryById(int catId)
        {
            DataTable dtCat;
            SqlDataReader catReader = null;
            try
            {
                //Creating command object
                SqlCommand catCommand = DataConnections.GenerateCommand();

                dtCat = new DataTable(/*int catId*/);
                catCommand.CommandText = "Group4.usp_SearchCategories";
                catCommand.Parameters.AddWithValue("@Category_Id", catId);
                catCommand.Connection.Open();
                catReader = catCommand.ExecuteReader();
                if (catReader.HasRows)
                {
                    dtCat.Load(catReader);
                }
                catReader.Close();
                catCommand.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtCat;
        }
    }
}
