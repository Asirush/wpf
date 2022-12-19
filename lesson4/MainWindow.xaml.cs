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

namespace lesson4
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

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            string login = tbxLogin.Text;
            string password = tbxPassword.Password;

            if(string.IsNullOrEmpty(login) )
            {
                lblLoginMessage.Content = "login can't be empty";
            }
            else
            {
                lblLoginMessage.Content = null;
            }
            if(string.IsNullOrEmpty(password) )
            {
                MessageBox.Show("Password can't be empty");
            }

            MainAuthWindow mainAuth = new();
            mainAuth.Show();
            this.Close();
        }
    }
}
