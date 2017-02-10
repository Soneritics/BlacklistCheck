using ServerMonitorShared;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BlacklistCheck.Blacklist
{
    [DataContract]
    public class BlacklistedServer
    {
        public Server server { get; private set; }
        public List<String> servicesChecked { get; private set; } = new List<String>();
        public List<String> blacklisted { get; private set; } = new List<String>();

        public BlacklistedServer(Server server, List<String> servicesChecked, List<String> blacklisted)
        {
            this.server = server;
            this.servicesChecked = servicesChecked;
            this.blacklisted = blacklisted;
        }
    }
}
