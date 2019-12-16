using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartCity.Business.Bus
{
    public interface IBusService
    {
        Task AddAsync(BusEntity entity);

        Task<ICollection<BusEntity>> GetAsync();

        Task<BusEntity> GetByIdAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(BusEntity bus);
    }
}
