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
using System.Net.NetworkInformation;
using System.Data.SqlClient;

namespace Server
{
    /// <summary>
    /// Interaction logic for AddUriPage.xaml
    /// </summary>
    public partial class AddUriPage : Window
    {
        public AddUriPage()
        {
            InitializeComponent();
        }

        private void btnAddUrlCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddUrlOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = new("'" + tbxAddUrl.Text + "'");
                

                SqlConnectionProvider sqlConnectionProvider = new();

                using (var connection = sqlConnectionProvider.GetOpenConnection())
                using (var command = new SqlCommand("INSERT INTO sites (url, url_status) VALUES (@url, @url_status)", connection))
                {
                    command.Parameters.AddWithValue("@url", tbxAddUrl.Text);
                    command.Parameters.AddWithValue("@url_status", 0);

                    var rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} rows were inserted into the sites table.");
                }
                Close();
            }
            catch {  }
        }
    }
}
