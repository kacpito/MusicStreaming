using MusicStreaming.Core;
using MusicStreaming.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicStreaming.MVVM.ViewModel
{
    class SongsViewModel : ObservableObject
    {
        public Album SelectedAlbum { get; set; }
        public Song SelectedSong { get; set; }
        public String Title { get; set; }
        public String Artist { get; set; }

        private List<Song> songs;

        public List<Song> Songs
        {
            get { return songs; }
            set
            {
                songs = value;
                OnPropertyChanged(nameof(songs));
            }
        }

        public SongsViewModel(Album album)
        {
            SelectedAlbum = album;
            Title = album.Title;

            using (var dbContext = new MusicStreamingDataContext())
            {
                songs = dbContext.Songs
                    .Where(s => s.Album_Id == SelectedAlbum.Id)
                    .ToList();

                Artist = songs[0].Artist;
            }
        }
    }
}
