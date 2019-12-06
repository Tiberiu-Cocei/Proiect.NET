using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartCity.Business.PointOfInterest
{
    public interface IPointOfInterestService
    {
        Task AddAsync(PointOfInterestEntity entity);

        Task<ICollection<PointOfInterestEntity>> GetAsync();

        Task<PointOfInterestEntity> GetByIdAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(PointOfInterestEntity pointOfInterest);
    }
}
