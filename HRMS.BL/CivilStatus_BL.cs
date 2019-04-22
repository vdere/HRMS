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
    /// CivilStatus ID :161611
    /// CivilStatus Name : Mansih
    /// Description : Validate CivilStatus details  and call CivilStatus  operations methods in DAL
    /// Date of Creation : 01/11/2018
    /// </summary>
    /// 
    public class CivilStatus_BL
    {
        //Validation of Details
        public static bool ValidatCivilStatus(CivilStatus newCVS)
        {

            bool isValidCVS = true;
            StringBuilder sbError = new StringBuilder();
            try
            {
                if (newCVS.StatusDescription == string.Empty)
                {
                    isValidCVS = false;
                    sbError.Append("Please Enter CivilStatus Description");
                }


                if (!isValidCVS)
                    throw new HRMSException(sbError.ToString());
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }

            return isValidCVS;
        }


        //Calling Add CivilStatus
        public static int AddCivilStatus_BL(CivilStatus newCVS)
        {
            int rowsAffected = 0;
            try
            {
                if (ValidatCivilStatus(newCVS))
                {
                    rowsAffected = CivilStatus_DAL.AddCivilStat(newCVS);
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


        //Calling Update CivilStatus
        public static int UpdateCivilStatus_BL(CivilStatus newCVS)
        {
            int rowsAffected = 0;
            try
            {
                if (ValidatCivilStatus(newCVS))
                {
                    rowsAffected = CivilStatus_DAL.UpdateCivilStat(newCVS);
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
        public static int GetAutogeneratedCivilStatusID_BL()
        {
            int CVSid = 0;
            try
            {


                CVSid = CivilStatus_DAL.GetAutoGeneratedCivilStatusId();



            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (HRMSException ex)
            {
                throw ex;
            }
            return CVSid;
        }


        //Delete CivilStatus
        public static int DeleteCivilStatus_BL(int CVSid)
        {
            int rowsAffected = 0;
            try
            {


                rowsAffected = CivilStatus_DAL.DeleteCivilStat(CVSid);



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

        //Search CivilStatus By Id
        public static DataTable SearchCivilStatusById_BL(int CVSid)
        {
            DataTable CVS = null;
            try
            {


                CVS = CivilStatus_DAL.SearchCivilStatById(CVSid);



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

        //Dispaly All CivilStatus
        public static DataTable DisplayCivilStatus_BL()
        {
            DataTable CVS = null;
            try
            {


                CVS = CivilStatus_DAL.DisplayAllCivilStats();



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
    }
}