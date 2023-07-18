using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MusicStreaming.Core;
using MusicStreaming.MVVM.Model;
using MusicStreaming.MVVM.View;

namespace MusicStreaming.MVVM.ViewModel
{
    /// <summary>
    /// Represents the main view model for managing different views.
    /// </summary>
    class MainViewModel : ObservableObject
    {
        /// <summary>
        /// Gets the command to switch to the home view.
        /// </summary>
        public RelayCommand HomeViewCommand { get; set; }
        /// <summary>
        /// Gets the command to switch to the albums view.
        /// </summary>
        public RelayCommand AlbumsViewCommand { get; set; }
        /// <summary>
        /// Gets the command to switch to the songs view.
        /// </summary>
        public RelayCommand SongsViewCommand { get; set; }
        /// <summary>
        /// Gets the command to switch to the favorites view.
        /// </summary>
        public RelayCommand FavoritesViewCommand { get; set; }
        /// <summary>
        /// Gets the command to add a song to favorites.
        /// </summary>
        public RelayCommand AddToFavoritesCommand { get; set; }
        /// <summary>
        /// Gets the command to remove a song from favorites.
        /// </summary>
        public RelayCommand RemoveFromFavoritesCommand { get; set; }

        /// <summary>
        /// Gets or sets the view model for the home view.
        /// </summary>
        public HomeViewModel HomeVM { get; set; }
        /// <summary>
        /// Gets or sets the view model for the albums view.
        /// </summary>
        public AlbumsViewModel AlbumsVM { get; set; }
        /// <summary>
        /// Gets or sets the view model for the songs view.
        /// </summary>
        public SongsViewModel SongsVM { get; set; }
        /// <summary>
        /// Gets or sets the view model for the favorites view.
        /// </summary>
        public FavoritesViewModel FavoritesVM { get; set; }

        private object _currentView;


        /// <summary>
        /// Gets or sets the current view.
        /// </summary>
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            AlbumsVM = new AlbumsViewModel();
            FavoritesVM = new FavoritesViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            AlbumsViewCommand = new RelayCommand(o =>
            {
                CurrentView = AlbumsVM;
            });

            SongsViewCommand = new RelayCommand(o =>
            {
                SongsVM = new SongsViewModel(AlbumsVM.SelectedAlbum);

                CurrentView = SongsVM;
            });

            FavoritesViewCommand = new RelayCommand(o =>
            {
                FavoritesVM = new FavoritesViewModel();

                CurrentView = FavoritesVM;
            });

            AddToFavoritesCommand = new RelayCommand(o =>
            {
                using (MusicStreamingDataContext context = new MusicStreamingDataContext())
                {
                    var favorite = new Favorite
                    {
                        Id_user = SessionManager.LoggedUserId,
                        Id_song = SongsVM.SelectedSong.Id,
                    };

                    context.Favorites.Add(favorite);
                    context.SaveChanges();
                }
            });

            RemoveFromFavoritesCommand = new RelayCommand(o =>
            {
                using (MusicStreamingDataContext context = new MusicStreamingDataContext())
                {
                    var favorite = new Favorite
                    {
                        Id_user = SessionManager.LoggedUserId,
                        Id_song = FavoritesVM.SelectedSong.Id,
                    };

                    context.Favorites.Remove(favorite);
                    context.SaveChanges();
                    FavoritesVM.LoadFavoriteSongs();
                }
            });
        }
    }
}
