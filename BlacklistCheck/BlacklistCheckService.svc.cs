using System;
using System.Collections.Generic;
using ServerMonitorShared;
using System.Linq;
using BlacklistCheck.Blacklist;

namespace BlacklistCheck
{
    public class BlacklistCheckService : IBlacklistCheckService
    {
        public List<BlacklistedServer> getBlacklistedIPs(List<string> ips)
        {
            List<Server> servers =
                (from ip in ips
                 select new Server(ip, ip)).ToList();

            return getBlacklistedServers(servers);
        }

        public List<BlacklistedServer> getBlacklistedServers(List<Server> servers)
        {
            var bc = BlacklistCheckFactory.Create(servers);
            return bc.getBlacklistedServers();
        }

        public bool isServerBlacklisted(Server server)
        {
            return isIpBlacklisted(server.IP);
        }

        public bool isIpBlacklisted(string ip)
        {
            return getBlacklistedIPs(new List<String>() { ip }).Where((bs) => bs.blacklisted.Count() > 0).Count() > 0;
        }
    }
}
