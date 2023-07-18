using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.MVVM.Model
{
    /// <summary>
    /// Represents a user entity.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the list of favorites associated with the user.
        /// </summary>
        public List<Favorite> Favorites { get; set; }
    }
}
