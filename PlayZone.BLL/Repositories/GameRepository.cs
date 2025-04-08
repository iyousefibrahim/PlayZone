using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayZone.BLL.Interfaces;
using PlayZone.DAL.Data.Contexts;
using PlayZone.DAL.Models;

namespace PlayZone.BLL.Repositories
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        private readonly PlayZoneDbContext _context;

        public GameRepository(PlayZoneDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
