using IdentityServer4.Models;
using MusicStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore
{
    public class Config
    {
        public static void SeedDatabase(DataContext db)
        {
            db.CdRecords.Add(new CdRecord()
            {
                Title = "Test_1",
                Comment = "Test Comment",
                Year = 2017,
                Author = "Author_B",
                Tracks = new List<Track>
                {
                    new Track { Title = "Track_1", TrackLength = "3.58" },
                    new Track { Title = "Track_2", TrackLength = "2.52" },
                    new Track { Title = "Track_3", TrackLength = "6.02" }
                }
            });

            db.CdRecords.Add(new CdRecord()
            {
                Title = "Test_2",
                Comment = "Test Comment",
                Year = 2015,
                Author = "Author_A",
                Tracks = new List<Track>
                {
                    new Track { Title = "Track_1", TrackLength = "2.27"},
                    new Track { Title = "Track_2", TrackLength = "3.58"},
                    new Track { Title = "Track_3", TrackLength = "9.15"}
                }
            });

            db.CdRecords.Add(new CdRecord()
            {
                Title = "Test_3",
                Comment = "Test Comment",
                Year = 2013,
                Author = "Author_B",
                Tracks = new List<Track>
                {
                    new Track { Title = "Track_1", TrackLength = "3.58"},
                    new Track { Title = "Track_2", TrackLength = "3.29"},
                    new Track { Title = "Track_3", TrackLength = "6.08"}
                }
            });

            db.CdRecords.Add(new CdRecord()
            {
                Title = "Test_4",
                Comment = "Test Comment",
                Year = 2011,
                Author = "Author_A",
                Tracks = new List<Track>
                {
                    new Track { Title = "Track_1", TrackLength = "5.24"},
                    new Track { Title = "Track_2", TrackLength = "3.58"},
                    new Track { Title = "Track_3", TrackLength = "5.32"}
                }
            });

            db.CdRecords.Add(new CdRecord()
            {
                Title = "Test_5",
                Comment = "Test Comment",
                Year = 2002,
                Author = "Author_C",
                Tracks = new List<Track>
                {
                    new Track { Title = "Track_1", TrackLength = "3.58"},
                    new Track { Title = "Track_2", TrackLength = "3.28"},
                    new Track { Title = "Track_3", TrackLength = "15.46"}
                }
            });

            db.SaveChanges();
        }
    }
}
