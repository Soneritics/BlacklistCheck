using BlacklistCheck.Blacklist;
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
        bool isIpBlacklisted(string ip);

        [OperationContract]
        bool isServerBlacklisted(Server server);

        [OperationContract]
        List<BlacklistedServer> getBlacklistedServers(List<Server> servers);

        [OperationContract]
        List<BlacklistedServer> getBlacklistedIPs(List<String> ips);
    }
}
