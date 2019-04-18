using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL
{
    /// <summary>
    /// Employee ID :161585
    /// Employee Name : Viraj Dere
    /// Description : Handles SQL Connections to Database
    /// Date of Creation : 10/23/2018
    /// </summary>
    public class DataConnections
    {
        //Function to create command object by assigning connection
        public static SqlCommand GenerateCommand()
        {
            SqlCommand cmd = null;

            try
            {
                //Creating connection object
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                //Creating Command object
                cmd = new SqlCommand();

                //Assigning common properties to command
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return cmd;
        }
    }
}
