using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.MVVM.ViewModel
{
    public static class SessionManager
    {
        public static int LoggedUserId { get; private set; }

        public static void SetLoggedUserId(int userId)
        {
            LoggedUserId = userId;
        }

        public static void ClearLoggedUserId()
        {
            LoggedUserId = 0;
        }
    }
}
