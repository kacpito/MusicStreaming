using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.MVVM.Model
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
