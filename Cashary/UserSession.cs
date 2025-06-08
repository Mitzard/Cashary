using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashary
{
    public static class UserSession
    {
        public static int LoggedInUserId { get; private set; }

        public static string LoggedInUsername { get; private set; }

        public static void StartSession(int userId, string username)
        {
            LoggedInUserId = userId;
            LoggedInUsername = username;
        }

        public static void EndSession()
        {
            LoggedInUserId = 0;
            LoggedInUsername = null;
        }
    }
}
