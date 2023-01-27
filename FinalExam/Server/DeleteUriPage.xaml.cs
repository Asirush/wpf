using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Server
{
    /// <summary>
    /// Interaction logic for DeleteUriPage.xaml
    /// </summary>
    public partial class DeleteUriPage : Window
    {
        public DeleteUriPage()
        {
            InitializeComponent();
        }

        private void btnDeleteUrlOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = new string("");
                url = tbxDeleteUrl.Text;

                SqlConnectionProvider sqlConnectionProvider = new();

                using (var connection = sqlConnectionProvider.GetOpenConnection())
                {
                    using (var command = new SqlCommand("DELETE FROM sites WHERE url = @url and url_status = @url_status", connection))
                    {
                        command.Parameters.AddWithValue("@url", url);
                        command.Parameters.AddWithValue("@url_status", 0);

                        var rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} rows were updated in the Customers table.");
                    }
                }
                this.Close();
                GetDataClass getDataClass = new GetDataClass();
                App._PageSitesList.ItemsSource = getDataClass.GetSitesFromSql();
            }
            catch {}
        }

        private void btnDeleteUrlCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
