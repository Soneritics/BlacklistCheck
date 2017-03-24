using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlacklistCheck.Blacklist
{
    public class BlacklistCheckFactoryConfiguration
    {
        public int CheckTimeoutMinutes;
        public List<BlacklistServer> BlacklistServers;

        public BlacklistCheckFactoryConfiguration(List<BlacklistServer> blacklistServers, int checkTimeoutMinutes)
        {
            CheckTimeoutMinutes = checkTimeoutMinutes;
            BlacklistServers = blacklistServers;
        }
    }
}