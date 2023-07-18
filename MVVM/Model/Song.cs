using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.MVVM.Model
{
    /// <summary>
    /// Represents a song entity.
    /// </summary>
    public class Song
    {
        /// <summary>
        /// Gets or sets the unique identifier of the song.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the title of the song.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the artist of the song.
        /// </summary>
        public string Artist { get; set; }
        /// <summary>
        /// Gets or sets the length of the song.
        /// </summary>
        public string Length { get; set; }
        /// <summary>
        /// Gets or sets the album ID associated with the song.
        /// </summary>
        public int Album_Id { get; set; }


        /// <summary>
        /// Gets or sets the album associated with the song.
        /// </summary>
        public Album Album { get; set; }
        /// <summary>
        /// Gets or sets the list of favorites associated with the song.
        /// </summary>
        public List<Favorite> Favorites { get; set; }

    }
}
