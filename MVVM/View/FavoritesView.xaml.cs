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

namespace MusicStreaming.MVVM.View
{
    /// <summary>
    /// Represents a user control that displays favorite songs.
    /// </summary>
    public partial class FavoritesView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FavoritesView"/> class.
        /// </summary>
        public FavoritesView()
        {
            InitializeComponent();
        }
    }
}
