﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Entity;
using HRMS.DAL;
using HRMS.Exceptions;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace HRMS.BL
{
    /// <summary>
    /// Category ID :161611
    /// Category Name : Mansih
    /// Description : Validate Category details  and call Category  operations methods in DAL
    /// Date of Creation : 01/11/2018
    /// </summary>
    /// 
    public class Category_BL
    {
        //Validation of Details
        public static bool ValidatCategory(Category newCat)
        {

            bool isValidCat = true;
            StringBuilder sbError = new StringBuilder();
            try
            {
                if (newCat.CategoryName == string.Empty)
                {
                    isValidCat = false;
                    sbError.Append("Please Enter Category Name");
                }
                else if (!Regex.IsMatch(newCat.CategoryName, "[A-Z][a-z]{2,}"))
                {
                    sbError.Append("Category  Name should start with Capital Alphabet, it should have minimum 3 characters and only alphabets\n");
                    isValidCat = false;
                }
                if (newCat.CategoryDescription == string.Empty)
                {
                    isValidCat = false;
                    sbError.Append("Please Enter MiddleName");
                }



                if (!isValidCat)
                    throw new HRMSException(sbError.ToString());
            }
            catch (HRMSException ex)
            {
                throw ex;
            }

            return isValidCat;
        }

        //Calling Add Category
        public static int AddCategory_BL(Category newCat)
        {
            int rowsAffected = 0;
            try
            {
                if (ValidatCategory(newCat))
                {
                    rowsAffected = Category_DAL.AddCategory(newCat);
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

        //Calling Update Category
        public static int UpdateCategory_BL(Category newCat)
        {
            int rowsAffected = 0;
            try
            {
                if (ValidatCategory(newCat))
                {
                    rowsAffected = Category_DAL.UpdateCategory(newCat);
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
        public static int GetAutogeneratedCategoryID_BL()
        {
            int Catid = 0;
            try
            {


                Catid = Category_DAL.GetAutoGeneratedCategoryId();



            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return Catid;
        }

        //Delete Category
        public static int DeleteCategory_BL(int Catid)
        {
            int rowsAffected = 0;
            try
            {
                rowsAffected = Category_DAL.DeleteCategory(Catid);

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

        //Search Category By Id
        public static DataTable SearchCategoryById_BL(int Catid)
        {
            DataTable Cat = null;
            try
            {


                Cat = Category_DAL.SearchCategoryById(Catid);



            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return Cat;
        }

        //Dispaly All Category
        public static DataTable DisplayCategory_BL()
        {
            DataTable Cat = null;
            try
            {


                Cat = Category_DAL.DisplayAllCategories();



            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return Cat;
        }
    }
}