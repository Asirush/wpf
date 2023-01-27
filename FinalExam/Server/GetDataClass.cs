using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Server
{
    internal class GetDataClass
    {
        public GetDataClass() { }
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
                Console.WriteLine(ex.Message);
                MessageBox.Show("Application has encountered error....");
                return null;
            }
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
