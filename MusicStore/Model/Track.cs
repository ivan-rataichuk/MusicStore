using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Model
{
    public class Track
    {
        public int Id { get; set; }

        public int CdRecordId { get; set; }
        public string Title { get; set; }
        public string TrackLength { get; set; }
        
    }
}
