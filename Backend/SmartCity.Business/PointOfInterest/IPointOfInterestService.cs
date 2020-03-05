using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartCity.Business.PointOfInterest
{
    public interface IPointOfInterestService
    {
        Task AddAsync(PointOfInterestEntity entity);

        Task<ICollection<PointOfInterestEntity>> GetAsync();

        Task<PointOfInterestEntity> GetByIdAsync(Guid id);

        Task<ICollection<PointOfInterestEntity>> GetByPersonIdAsync(Guid personId);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(PointOfInterestEntity pointOfInterest);

        Task<ICollection<PointOfInterestEntity>> GetByCityName(string cityName);
    }
}
