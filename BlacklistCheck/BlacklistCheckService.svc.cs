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
            var bc = BlacklistCheckFactory.Create();
            throw new NotImplementedException();
        }

        public bool isServerBlacklisted(Server server)
        {
            return isIpBlacklisted(server.IP);
        }

        public bool isIpBlacklisted(string ip)
        {
            return getBlacklistedIPs(new List<String>() { ip }).Count == 1;
        }
    }
}
