using System;

namespace DAL
{
    public static class DConConfig
    {
        public static string ConnectionString
        {
            get { return System.Configuration.ConfigurationManager.ConnectionStrings["SecureProctor"].ToString(); }
        }
        public static string ConnectionStringPortal
        {
            get { return System.Configuration.ConfigurationManager.ConnectionStrings["Portal"].ToString(); }
        }

    }
}
