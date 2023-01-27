using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
using System.Net.NetworkInformation;

namespace Server
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

        public bool CheckConnection(string connectionString)
        {

            Ping ping = new Ping();
            PingReply reply = ping.Send(connectionString);

            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Ping successful.");
                return true;
            }
            else
            {
                Console.WriteLine("Ping failed.");
                return false;
            }

        }

        private void BtnAddUrl_Click(object sender, RoutedEventArgs e)
        {
            AddUriPage addUriPage = new AddUriPage();
            addUriPage.Show();
        }

        private void BtnDeleteUrl_Click(object sender, RoutedEventArgs e)
        {
            DeleteUriPage deleteUriPage = new DeleteUriPage();
            deleteUriPage.Show();
        }

        private void BtnUpdateUrl_Click(object sender, RoutedEventArgs e)
        {
            GetDataClass getDataClass = new GetDataClass();
            App._PageSitesList.ItemsSource = getDataClass.GetSitesFromSql();
        }
    }
}
