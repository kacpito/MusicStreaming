using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.MVVM.ViewModel
{
    /// <summary>
    /// Provides a static class for managing the logged user session.
    /// </summary>
    public static class SessionManager
    {
        /// <summary>
        /// Gets the logged user ID.
        /// </summary>
        public static int LoggedUserId { get; private set; }


        /// <summary>
        /// Sets the logged user ID.
        /// </summary>
        /// <param name="userId">The ID of the logged user.</param>
        public static void SetLoggedUserId(int userId)
        {
            LoggedUserId = userId;
        }

        /// <summary>
        /// Clears the logged user ID.
        /// </summary>
        public static void ClearLoggedUserId()
        {
            LoggedUserId = 0;
        }
    }
}
