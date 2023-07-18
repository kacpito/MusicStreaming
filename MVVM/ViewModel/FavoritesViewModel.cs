using MusicStreaming.Core;
using MusicStreaming.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.MVVM.ViewModel
{
    /// <summary>
    /// Represents the view model for displaying favorite songs.
    /// </summary>
    class FavoritesViewModel : ObservableObject
    {
        private List<Song> _songs = new List<Song>();
        /// <summary>
        /// Gets or sets the selected song.
        /// </summary>
        public Song SelectedSong { get; set; }
        /// <summary>
        /// Gets or sets the username associated with the favorite songs.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the list of favorite songs.
        /// </summary>
        public List<Song> FavoriteSongs
        {
            get { return _songs; }
            set
            {
                _songs = value;
                OnPropertyChanged(nameof(_songs));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FavoritesViewModel"/> class.
        /// </summary>
        public FavoritesViewModel()
        {
            LoadFavoriteSongs();
        }

        /// <summary>
        /// Loads the favorite songs associated with the current user.
        /// </summary>
        public void LoadFavoriteSongs()
        {
            using (var dbContext = new MusicStreamingDataContext())
            {
                Username = dbContext.Users
                                  .Where(u => u.Id == SessionManager.LoggedUserId)
                                  .Select(u => u.Username)
                                  .FirstOrDefault();

                Username += "'s playlist";

                List<Song> songs = dbContext.Favorites
                                    .Where(f => f.Id_user == SessionManager.LoggedUserId)
                                    .Select(f => f.Song)
                                    .ToList();

                FavoriteSongs.Clear();
                foreach (Song song in songs)
                {
                    FavoriteSongs.Add(song);
                }

            }
        }
    }
}
