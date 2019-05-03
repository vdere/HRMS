using System;
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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using HRMS.Entity;
using HRMS.Exceptions;
using HRMS.BL;


namespace HRMS
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Users newUser = new Users();

                newUser.UserName = textBox_UserName.Text;
                newUser.Password = passwordBox.Password.ToString();
                newUser.FirstName = textBox_FirstName.Text;
                newUser.LastName = textBox_LastName.Text;

                int rowsAffected = UserValidation.AddClerk_BLL(newUser);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Sign Up Successful");
                }
                else
                    MessageBox.Show("Signup Failed");
            }
            catch (HRMSException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
