using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.MVVM.Model
{
    /// <summary>
    /// Represents a favorite entity that associates a user with a song.
    /// </summary>
    public class Favorite
    {
        /// <summary>
        /// Gets or sets the user ID associated with the favorite.
        /// </summary>
        public int Id_user { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the favorite.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the song ID associated with the favorite.
        /// </summary>
        public int Id_song { get; set; }

        /// <summary>
        /// Gets or sets the song associated with the favorite.
        /// </summary>
        public Song Song { get; set; }
    }
}
