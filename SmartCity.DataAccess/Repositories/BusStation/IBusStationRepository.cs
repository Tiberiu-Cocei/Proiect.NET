using SmartCity.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SmartCity.DataAccess.Repositories.BusStation
{
    public interface IBusStationRepository : IBaseRepository<BusStationEntity>
    {
        Task Delete(Guid id);

        Task<BusStationEntity> GetByCoordonates(CoordinatesEntity coordinates);
    }
}
