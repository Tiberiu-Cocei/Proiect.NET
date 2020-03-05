using SmartCity.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartCity.DataAccess.Repositories.PointOfInterest
{
    public interface IPointOfInterestRepository : IBaseRepository<PointOfInterestEntity>
    {
        public Task<PointOfInterestEntity> GetByCoordonates(CoordinatesEntity coordinate);
        public Task<ICollection<PointOfInterestEntity>> GetByPersonId(Guid personId);
        Task Delete(Guid id);

        Task<ICollection<PointOfInterestEntity>> GetByCityName(string cityName);
    }
}
