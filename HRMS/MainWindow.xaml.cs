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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmb_login_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_clerk_signup_Click(object sender, RoutedEventArgs e)
        {
            Signup su = new Signup();
            su.Show();
        }

        private void btn_clerk_login_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_login.SelectedIndex == 0)
            {
                HRClerkDatabase hrcd = new HRClerkDatabase();
                hrcd.Show();
            }
            else if (cmb_login.SelectedIndex == 1)
            {
                AdminDatabase admindb = new AdminDatabase();
                admindb.Show();
            }
            else
            {

            }
        }
    }
}
