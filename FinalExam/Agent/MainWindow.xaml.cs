using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon("Main.ico");
            ni.Visible = true;
            ni.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };
            while(true)
            {
                List<Site> sites = GetSitesFromSql();
                foreach (Site site in sites)
                {
                    if (PingHost(site)) { }
                    else {
                        NotifyIcon notifyIcon = new NotifyIcon();
                        notifyIcon.Icon = new System.Drawing.Icon("Main.ico");
                        notifyIcon.Visible = true;
                        notifyIcon.ShowBalloonTip(5000, "Site is not available", site.Url, ToolTipIcon.Info);
                    }
                }
                System.Threading.Thread.Sleep(5000);
            }

        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Minimized)
                this.Hide();

            base.OnStateChanged(e);
        }
        public class Site
        {
            public string Url { get; set; }
            public bool UrlStatus { get; set; }

            public string SiteAvailability
            {
                get
                {
                    if (UrlStatus) return "available";
                    else return "not available";
                }
            }
        }

        public List<Site> GetSitesFromSql()
        {
            try
            {
                List<Site> sites = new List<Site>();
                SqlConnectionProvider provider = new SqlConnectionProvider();

                using (var connection = provider.GetOpenConnection())
                {
                    using (var command = new SqlCommand("SELECT url, url_status FROM sites", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Site site = new Site();
                                site.Url = (string)reader["url"];
                                site.UrlStatus = (bool)reader["url_status"];
                                sites.Add(site);
                            }
                        }
                    }
                }
                return sites;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool EditSiteAvailability(Site site, Site new_site)
        {
            try
            {
                SqlConnectionProvider sqlConnectionProvider = new SqlConnectionProvider();

                using (var connection = sqlConnectionProvider.GetOpenConnection())
                using (var command = new SqlCommand("UPDATE sites SET url = '@new_url', url_status = '@new_url_status' WHERE url = 'old_url'", connection))
                {
                    command.Parameters.AddWithValue("@new_url", new_site.Url);
                    command.Parameters.AddWithValue("@new_url_status", new_site.UrlStatus);
                    command.Parameters.AddWithValue("@old_url", site.Url);

                    var rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} rows were inserted into the sites table.");
                }
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public static bool PingHost(Site site)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(site.Url);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
    }
}
