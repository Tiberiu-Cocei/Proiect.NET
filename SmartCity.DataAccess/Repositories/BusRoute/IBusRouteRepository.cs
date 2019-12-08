using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartCity.DataAccess.Repositories.BusRoute
{
    public interface IBusRouteRepository : IBaseRepository<BusRouteEntity>
    {
        Task Delete(Guid id);
    }
}
