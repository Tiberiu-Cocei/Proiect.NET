using SmartCity.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SmartCity.DataAccess.Repositories.PointOfInterest
{
    public interface IPointOfInterestRepository : IBaseRepository<PointOfInterestEntity>
    {
        public Task<PointOfInterestEntity> GetByCoordonates(CoordinatesEntity coordinate);
        public Task<PointOfInterestEntity> GetByPersonId(Guid personId);
        Task Delete(Guid id);
    }
}
