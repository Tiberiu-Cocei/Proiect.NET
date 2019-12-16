using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartCity.Business.BusRoute
{
    public interface IBusRouteService
    {
        Task AddAsync(BusRouteEntity entity);

        Task<ICollection<BusRouteEntity>> GetAsync();

        Task<BusRouteEntity> GetByIdAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(BusRouteEntity busRouteService);
    }
}
