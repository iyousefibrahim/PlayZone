using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayZone.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IGameRepository GameRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IDeviceRepository DeviceRepository { get; }


        public Task SaveChangesAsync();

        public ValueTask DisposeAsync();
    }
}
