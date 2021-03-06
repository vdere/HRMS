﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HRMS.Entity;
using HRMS.Exceptions;
using HRMS.BL;
using System.Data.SqlClient;
using System.Data;

namespace HRMS
{
    /// <summary>
    /// Interaction logic for AdminDatabase.xaml
    /// </summary>
    public partial class AdminDatabase : Window
    {
        public AdminDatabase()
        {
            InitializeComponent();
        }

        //Window Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBox_AdminSpeciality_ID.Text = Speciality_BL.GetAutogeneratedSpecialityID_BL().ToString();
        }

        private void dg_AdminSpeciality_Details_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //Admin Users
        private void btn_AdminUsers_Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AdminUsers_Display_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AdminUsers_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AdminUsers_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AdminUsers_Reset_Click(object sender, RoutedEventArgs e)
        {
            textBox_AdminUsers_ID.Clear();
            textBox_AdminUsers_Name.Clear();
            passBox_AdminUsers_Password.Clear();
            textBox_AdminUsers_FirstName.Clear();
            textBox_AdminUsers_LastName.Clear();
        }

        private void btn_AdminUsers_Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dg_AdminUsers_Details_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Admin Civil Status
        private void btn_Admin_CivilStatus_Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Admin_CivilStatus_Display_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Admin_CivilStatus_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Admin_CivilStatus_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Admin_CivilStatus_Reset_Click(object sender, RoutedEventArgs e)
        {
            textBox_Admin_CivilStatus_ID.Clear();
            textBox_Admin_CivilStatus_Description.Clear();
        }

        private void btn_Admin_CivilStatus_Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dg_Admin_CivilStatus_Details_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Admin Level
        private void btn_AdminLevel_Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AdminLevel_Display_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AdminLevel_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AdminLevel_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AdminLevel_Reset_Click(object sender, RoutedEventArgs e)
        {
            textBox_AdminLevel_ID.Clear();
            textBox_AdminLevel_Description.Clear();
        }

        private void btn_AdminLevel_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int specId = Convert.ToInt32(textBox_AdminSpeciality_ID.Text);
                DataTable sEd = Speciality_BL.SearchSpecialityById_BL(specId);

                DataRow dr = sEd.Rows[0];
                if (!dr.IsNull("Speciality_Id"))
                {
                    textBox_AdminSpeciality_ID.Text = dr["Speciality_Id"].ToString();
                    textBox_AdminSpeciality_Name.Text = dr["Speciality_Name"].ToString();
                }
                else
                    MessageBox.Show("No Records found with Speciality Id : " + specId);
            }
            catch (HRMSException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Admin Speciality
        private void btn_AdminSpeciality_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Speciality newSpec = new Speciality();

                newSpec.SpecialityId = Convert.ToInt32(textBox_AdminSpeciality_ID.Text);
                newSpec.SpecialityName = textBox_AdminSpeciality_Name.Text;

                int rowsAffected = Speciality_BL.AddSpeciality_BL(newSpec);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Speciality Added !!");
                }
                else
                    MessageBox.Show("Error!!! Speciality Record not Added");
            }
            catch (HRMSException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_AdminSpeciality_Display_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dtSpec = Speciality_BL.DisplaySpeciality_BL();
                dg_AdminSpeciality_Details.ItemsSource = dtSpec.DefaultView;
            }
            catch (HRMSException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_AdminSpeciality_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int specId = Convert.ToInt32(textBox_AdminSpeciality_ID.Text);

                int rowsAffected = Speciality_BL.DeleteSpeciality_BL(specId);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Speciality Details Deleted !!");
                }
                else MessageBox.Show("Error!!! Speciality Record not found");
            }
            catch (HRMSException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_AdminSpeciality_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Speciality newSpec = new Speciality();

                newSpec.SpecialityId = Convert.ToInt32(textBox_AdminSpeciality_ID.Text);
                newSpec.SpecialityName = textBox_AdminSpeciality_Name.Text;

                int rowsAffected = Speciality_BL.UpdateSpeciality_BL(newSpec);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Speciality Updated !!");
                }
                else
                    MessageBox.Show("Error!!! Speciality Record not Updated");
            }
            catch (HRMSException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btn_AdminSpeciality_Reset_Click(object sender, RoutedEventArgs e)
        {
            textBox_AdminSpeciality_ID.Text = Speciality_BL.GetAutogeneratedSpecialityID_BL().ToString();
            textBox_AdminSpeciality_Name.Clear();
        }

        private void btn_AdminSpeciality_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int specId = Convert.ToInt32(textBox_AdminSpeciality_ID.Text);
                DataTable sEd = Speciality_BL.SearchSpecialityById_BL(specId);

                DataRow dr = sEd.Rows[0];
                if (!dr.IsNull("Speciality_Id"))
                {
                    textBox_AdminSpeciality_ID.Text = dr["Speciality_Id"].ToString();
                    textBox_AdminSpeciality_Name.Text = dr["Speciality_Name"].ToString();
                }
                else
                    MessageBox.Show("No Records found with Speciality Id : " + specId);
            }
            catch (HRMSException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }    
}
