using MusicStreaming.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MusicStreaming.MVVM.ViewModel;

namespace MusicStreaming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            SessionManager.ClearLoggedUserId();
            this.Close();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            btnDisplay.Visibility = Visibility.Collapsed;
            btnAddToFav.Visibility = Visibility.Collapsed;
            btnRemoveFromFav.Visibility = Visibility.Collapsed;
        }

        private void btnAlbum_Click(object sender, RoutedEventArgs e)
        {
            btnDisplay.Visibility = Visibility.Visible;
            btnAddToFav.Visibility = Visibility.Collapsed;
            btnRemoveFromFav.Visibility = Visibility.Collapsed;
        }

        private void btnFav_Click(object sender, RoutedEventArgs e)
        {
            btnDisplay.Visibility = Visibility.Collapsed;
            btnAddToFav.Visibility = Visibility.Collapsed;
            btnRemoveFromFav.Visibility = Visibility.Visible;
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            btnDisplay.Visibility = Visibility.Collapsed;
            btnAddToFav.Visibility = Visibility.Visible;
            btnRemoveFromFav.Visibility = Visibility.Collapsed;
        }
    }
}
