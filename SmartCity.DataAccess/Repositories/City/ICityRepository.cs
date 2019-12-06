using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartCity.DataAccess.Repositories.City
{
    public interface ICityRepository: IBaseRepository<CityEntity>
    {
        Task<CityEntity> GetByName(string name);
    }
}
