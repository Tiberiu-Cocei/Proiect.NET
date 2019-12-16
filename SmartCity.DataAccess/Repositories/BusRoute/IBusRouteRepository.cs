using SmartCity.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SmartCity.DataAccess.Repositories.BusRoute
{
    public interface IBusRouteRepository : IBaseRepository<BusRouteEntity>
    {
        Task Delete(Guid id);
    }
}
