using LinqToDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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

        public string SiteAvailability { get
            {
                if (UrlStatus) return "available";
                else return "not available";
            } }
    }

    public partial class UrlFrame : Page
    {
        
        public UrlFrame()
        {
            InitializeComponent();
            GetDataClass getDataClass = new GetDataClass();
            DataContext = this;
            List<Site> sites = getDataClass.GetSitesFromSql();
            PageSitesList.ItemsSource = sites;
            StatusConverter statusConverter = new StatusConverter();

            App._PageSitesList = PageSitesList;
        }
    }
}
