using ServerMonitorShared;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace BlacklistCheck.Blacklist
{
    static class BlacklistCheckFactory
    {
        private static Dictionary<String, BlacklistCheck> BlacklistChecks = new Dictionary<String, BlacklistCheck>();

        public static BlacklistCheck Create(List<Server> servers)
        {
            var hash = calculateHash(servers);
            if (!BlacklistChecks.ContainsKey(hash))
            {
                BlacklistChecks[hash] = new BlacklistCheck(getConfiguration(), servers);
            }

            return BlacklistChecks[hash];
        }

        private static BlacklistCheckFactoryConfiguration getConfiguration()
        {
            int checkTimeoutMinutes = int.Parse(ConfigurationManager.AppSettings["CheckTimeoutMinutes"]);
            var blacklists = getBlacklistServers((ConfigurationManager.GetSection("blacklists") as NameValueCollection));

            return new BlacklistCheckFactoryConfiguration(blacklists, checkTimeoutMinutes);
        }

        private static List<BlacklistServer> getBlacklistServers(NameValueCollection blacklistCollection)
        {
            var result = new List<BlacklistServer>();
            foreach (String blacklist in blacklistCollection.Keys)
            {
                var server = new BlacklistServer();
                server.Name = blacklist;
                server.DNS = blacklistCollection[blacklist];
                result.Add(server);
            }

            return result;
        }

        private static string calculateHash(List<Server> servers)
        {
            return String.Join("|",
                (from s in servers
                 orderby s.ToString()
                 select s.ToString()).ToArray());
        }
    }
}
