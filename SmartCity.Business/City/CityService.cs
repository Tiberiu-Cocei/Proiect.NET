using SmartCity.Business.City;
using SmartCity.DataAccess.Repositories.City;
using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.Business.Person
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            Guard.ArgumentNotNull(cityRepository, nameof(cityRepository));

            _cityRepository = cityRepository;
        }

        public async Task AddAsync(CityEntity city)
        {
            Guard.ArgumentNotNull(city, nameof(city));

            await _cityRepository.Add(city).ConfigureAwait(false);
        }

        public async Task<ICollection<CityEntity>> GetAsync()
        {
            return await _cityRepository.Get().ConfigureAwait(false);
        }

        public async Task<CityEntity> GetByIdAsync(Guid id)
        {
            Guard.ArgumentNotNull(id, nameof(id));

            return await _cityRepository.GetById(id).ConfigureAwait(false);
        }

        public async Task<CityEntity> GetByNameAsync(string name)
        {
            Guard.ArgumentNotNull(name, nameof(name));

            return await _cityRepository.GetByName(name).ConfigureAwait(false);
        }

        public async Task UpdateAsync(CityEntity city)
        {
            Guard.ArgumentNotNull(city, nameof(city));

            var tetDb = await _cityRepository.GetById(city.Id).ConfigureAwait(false);
            if(tetDb != null)
            {
                await _cityRepository.Update(city).ConfigureAwait(false);
            }
        }
    }
}
