using MusicStreaming.Core;
using MusicStreaming.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace MusicStreaming.MVVM.ViewModel
{
    /// <summary>
    /// Represents the view model for displaying albums.
    /// </summary>
    class AlbumsViewModel : ObservableObject
    {
        private List<Album> albums;

        /// <summary>
        /// Gets or sets the selected album.
        /// </summary>
        public Album SelectedAlbum { get; set; }


        /// <summary>
        /// Gets or sets the list of albums.
        /// </summary>
        public List<Album> Albums
        {
            get { return albums; }
            set
            {
                albums = value;
                OnPropertyChanged(nameof(Albums));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsViewModel"/> class.
        /// </summary>
        public AlbumsViewModel()
        {
            using (var dbContext = new MusicStreamingDataContext())
            {
                Albums = dbContext.Albums.ToList();
            }
        }
    }
}
