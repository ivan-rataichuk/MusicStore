using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;

namespace MusicStore.Controllers
{
    public enum Sorting
    {
        Title,
        Author,
        Year
    }

    [Route("api/[controller]")]
    [Authorize]
    public class StoreController : Controller
    {
        private DataContext _db;

        public StoreController(DataContext db)
        {
            _db = db;
        }

        [HttpGet("[action]/{sorting}/{skip}/{take}")]
        public RecordsResponse Records(Sorting sorting = Sorting.Title, int skip = 0, int take = 0)
        {
            Expression<Func<CdRecord, string>> sort = r => r.Title;
            
            switch (sorting)
            {
                case Sorting.Author:
                    sort = r => r.Author;
                    break;

                case Sorting.Year:
                    sort = r => r.Year.ToString();
                    break;
            }

            return new RecordsResponse
            {
                RecordsCount = _db.CdRecords.Count(),
                Records = _db.CdRecords.Include(r => r.Tracks).OrderBy(sort).Skip(skip).Take(take)
            };
        }
    }

    public class RecordsResponse
    {
        public IEnumerable<CdRecord> Records { get; set; }
        public int RecordsCount { get; set; }
    }
}
