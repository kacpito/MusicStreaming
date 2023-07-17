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
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand AlbumsViewCommand { get; set; }
        public RelayCommand SongsViewCommand { get; set; }
        public RelayCommand FavoritesViewCommand { get; set; }
        public RelayCommand AddToFavoritesCommand { get; set; }
        public RelayCommand RemoveFromFavoritesCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public AlbumsViewModel AlbumsVM { get; set; }
        public SongsViewModel SongsVM { get; set; }
        public FavoritesViewModel FavoritesVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

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
