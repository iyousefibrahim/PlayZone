using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayZone.BLL.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(Guid id);
    }
}
