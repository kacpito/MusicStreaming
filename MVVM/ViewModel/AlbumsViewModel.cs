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
    class AlbumsViewModel : ObservableObject
    {
        private List<Album> albums;
        public Album SelectedAlbum { get; set; }


        public List<Album> Albums
        {
            get { return albums; }
            set
            {
                albums = value;
                OnPropertyChanged(nameof(Albums));
            }
        }

        public AlbumsViewModel() 
        {
            using (var dbContext = new MusicStreamingDataContext())
            {
                Albums = dbContext.Albums.ToList();
            }
        }
    }
}
