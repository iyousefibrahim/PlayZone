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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly PlayZoneDbContext _context;
        public CategoryRepository(PlayZoneDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
