using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Model
{
    public class CdRecord
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Comment { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
