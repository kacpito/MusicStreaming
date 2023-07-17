using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.MVVM.Model
{
    public class Favorite
    {
        public int Id_user { get; set; }
        public User User { get; set; }

        public int Id_song { get; set; }
        public Song Song { get; set; }
    }
}
