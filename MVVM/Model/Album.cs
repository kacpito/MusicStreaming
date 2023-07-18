using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.MVVM.Model
{
    /// <summary>
    /// Represents an album entity.
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Gets or sets the unique identifier of the album.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the album.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the collection of songs in the album.
        /// </summary>
        public ICollection<Song> Songs { get; set; }
    }
}
