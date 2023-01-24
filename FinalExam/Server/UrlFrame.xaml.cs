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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Server
{
    public class Site
    {
        public string Url { get; set; }
        public bool UrlStatus { get; set; }
    }
    /// <summary>
    /// Interaction logic for UrlFrame.xaml
    /// </summary>
    public partial class UrlFrame : Page
    {
        public UrlFrame()
        {
            InitializeComponent();

            SqlConnectionProvider provider = new SqlConnectionProvider();

                List<Site> sites = new List<Site>();
                using (var connection = provider.GetOpenConnection())
                using (var command = new SqlCommand("SELECT  url, url_status FROM sites", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var url = reader.GetString(0);
                        var urlStatus = reader.GetBoolean(1);
                        sites.Add(new Site { Url = url, UrlStatus = urlStatus });
                    }
                }
        }
    }
}
