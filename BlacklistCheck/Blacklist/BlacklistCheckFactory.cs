using System;
using System.Collections.Generic;
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
            var sec = ConfigurationManager.GetSection("blacklists");
            return new BlacklistCheckFactoryConfiguration();
        }
    }

    struct BlacklistServer
    {
        public String Name;
        public String DNS;
    }

    struct BlacklistCheckFactoryConfiguration
    {
        public String hash;
        public int CheckTimeoutMinutes;
        public List<BlacklistServer> BlacklistServers;
    }
}
