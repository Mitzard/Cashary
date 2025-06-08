using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashary
{
    public static class DBConfig
    {
        public static string dbServer = "localhost";
        public static string dbUser = "root";
        public static string dbName = "cashary";
        public static string dbPass = "";

        public static string ConnStr = $"server={dbServer};user={dbUser};database={dbName};password={dbPass};";
    }
}
