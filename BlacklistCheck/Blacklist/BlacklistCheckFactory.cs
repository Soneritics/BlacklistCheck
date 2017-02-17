using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace BlacklistCheck.Blacklist
{
    static class BlacklistCheckFactory
    {
        private static Dictionary<String, BlacklistCheck> BlacklistChecks = new Dictionary<String, BlacklistCheck>();

        public static BlacklistCheck Create()
        {
            var config = getConfiguration();
            return new BlacklistCheck();
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
    }

    class BlacklistServer
    {
        public String Name;
        public String DNS;
    }

    class BlacklistCheckFactoryConfiguration
    {
        public String hash;
        public int CheckTimeoutMinutes;
        public List<BlacklistServer> BlacklistServers;

        public BlacklistCheckFactoryConfiguration(List<BlacklistServer> blacklistServers, int checkTimeoutMinutes)
        {
            CheckTimeoutMinutes = checkTimeoutMinutes;
            BlacklistServers = blacklistServers;
        }
    }
}
