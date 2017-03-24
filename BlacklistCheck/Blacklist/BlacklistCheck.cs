using ServerMonitorShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlacklistCheck.Blacklist
{
    class BlacklistCheck
    {
        protected BlacklistCheckFactoryConfiguration blacklistCheckFactoryConfiguration { get; }
        protected List<Server> servers { get; }

        public BlacklistCheck(BlacklistCheckFactoryConfiguration blacklistCheckFactoryConfiguration, List<Server> servers)
        {
            this.blacklistCheckFactoryConfiguration = blacklistCheckFactoryConfiguration;
            this.servers = servers;
        }

        public List<BlacklistedServer> getBlacklistedServers()
        {
            return servers.Select((s) => checkServer(s)).ToList();
        }

        private BlacklistedServer checkServer(Server server)
        {
            List<String> servicesChecked = new List<String>();
            List<String> blacklisted = new List<String>();

            Parallel.ForEach(blacklistCheckFactoryConfiguration.BlacklistServers, (bs) => {
                servicesChecked.Add(bs.Name);

                if (isBlacklisted(bs, server))
                {
                    blacklisted.Add(bs.Name);
                }
            });

            return new BlacklistedServer(server, servicesChecked, blacklisted);
        }

        private bool isBlacklisted(BlacklistServer bs, Server server)
        {
            var ipSplit = server.IP.Split('.');
            Array.Reverse(ipSplit);
            var ipReverse = String.Join(".", ipSplit);

            var location = ipReverse + "." + bs.DNS;
            bool found = false;
            try
            {
                IPHostEntry iph = Dns.GetHostEntry(location);
                found = iph.AddressList.Length > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message} - {location}");
            }

            return found;
        }
    }
}
