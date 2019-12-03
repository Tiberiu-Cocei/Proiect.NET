using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartCity.Business.PointOfInterest
{
    public interface IPointOfInterestService
    {
        Task<ICollection<PointOfInterestEntity>> GetAsync();

        Task<PointOfInterestEntity> GetByIdAsync(Guid id); 
    }
}
