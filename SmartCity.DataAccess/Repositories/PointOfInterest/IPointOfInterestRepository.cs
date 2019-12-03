using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartCity.DataAccess.Repositories.PointOfInterest
{
    public interface IPointOfInterestRepository : IBaseRepository<PointOfInterestEntity>
    {
        public Task<PointOfInterestEntity> GetByCoordonates(CoordinatesEntity coordinate);
    }
}
