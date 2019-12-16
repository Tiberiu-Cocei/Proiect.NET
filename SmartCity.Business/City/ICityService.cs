using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartCity.Business.City
{
    public interface ICityService
    {
        Task<ICollection<CityEntity>> GetAsync();

        Task<CityEntity> GetByIdAsync(Guid id);

        Task AddAsync(CityEntity city);

        Task UpdateAsync(CityEntity city);

        Task<CityEntity> GetByNameAsync(string name);
    }
}
