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
    /// <summary>
    /// Represents the view model for displaying songs of a selected album.
    /// </summary>
    class SongsViewModel : ObservableObject
    {
        /// <summary>
        /// Gets or sets the selected album.
        /// </summary>
        public Album SelectedAlbum { get; set; }

        /// <summary>
        /// Gets or sets the selected song.
        /// </summary>
        public Song SelectedSong { get; set; }

        /// <summary>
        /// Gets or sets the title of the selected album.
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// Gets or sets the artist of the selected album.
        /// </summary>
        public String Artist { get; set; }


        private List<Song> songs;

        /// <summary>
        /// Gets or sets the list of songs.
        /// </summary>
        public List<Song> Songs
        {
            get { return songs; }
            set
            {
                songs = value;
                OnPropertyChanged(nameof(songs));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SongsViewModel"/> class.
        /// </summary>
        /// <param name="album">The selected album.</param>
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
