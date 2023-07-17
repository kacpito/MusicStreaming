using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.MVVM.Model
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Length { get; set; }
        public int Album_Id { get; set; }

        public Album Album { get; set;}
        public List<Favorite> Favorites { get; set; }

    }
}
