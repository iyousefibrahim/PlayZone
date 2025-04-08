using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayZone.BLL.Interfaces;
using PlayZone.DAL.Data.Contexts;

namespace PlayZone.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlayZoneDbContext _context;

        public UnitOfWork(PlayZoneDbContext context)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(_context);
            GameRepository = new GameRepository(_context);
            DeviceRepository = new DeviceRepository(_context);
        }
        public IGameRepository GameRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IDeviceRepository DeviceRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

    }
}
