using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartCity.Business.BusStation
{
    public interface IBusStationService
    {
        Task AddAsync(BusStationEntity entity);

        Task<ICollection<BusStationEntity>> GetAsync();

        Task<BusStationEntity> GetByIdAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(BusStationEntity busStationEntity);
    }
}
