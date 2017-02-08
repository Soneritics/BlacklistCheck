using ServerMonitorShared;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace BlacklistCheck
{
    [ServiceContract]
    public interface IBlacklistCheckService
    {
        [OperationContract]
        bool isBlacklisted(string ip);

        [OperationContract]
        bool isBlacklisted(Server server);

        List<BlacklistedServer> getBlacklistedServers(List<Server> servers);

        List<BlacklistedServer> getBlacklistedIPs(List<String> ips);
    }

    [DataContract]
    public class BlacklistedServer
    {
        public Server server { get; private set; }
        public List<String> servicesChecked { get; private set; }  = new List<String>();
        public List<String> blacklisted { get; private set; } = new List<String>();
    }
}
