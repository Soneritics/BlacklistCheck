using System;
using System.Collections.Generic;
using ServerMonitorShared;

namespace BlacklistCheck
{
    public class BlacklistCheckService : IBlacklistCheckService
    {
        public List<BlacklistedServer> getBlacklistedIPs(List<string> ips)
        {
            throw new NotImplementedException();
        }

        public List<BlacklistedServer> getBlacklistedServers(List<Server> servers)
        {
            throw new NotImplementedException();
        }

        public bool isBlacklisted(Server server)
        {
            throw new NotImplementedException();
        }

        public bool isBlacklisted(string ip)
        {
            throw new NotImplementedException();
        }
    }
}
