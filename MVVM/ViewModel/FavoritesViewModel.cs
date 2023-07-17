using MusicStreaming.Core;
using MusicStreaming.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.MVVM.ViewModel
{
    class FavoritesViewModel : ObservableObject
    {
        private List<Song> _songs = new List<Song>();
        public Song SelectedSong { get; set; }
        public string Username { get; set; }
        public List<Song> FavoriteSongs
        {
            get { return _songs; }
            set
            {
                _songs = value;
                OnPropertyChanged(nameof(_songs));
            }
        }


        public FavoritesViewModel()
        {
            LoadFavoriteSongs();
        }

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
