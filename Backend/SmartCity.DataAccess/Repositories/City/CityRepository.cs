using MongoDB.Driver;
using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.DataAccess.Repositories.City
{
    public class CityRepository : ICityRepository
    {
        private readonly IMongoCollection<CityEntity> _cities;

        public CityRepository(DatabaseContext databaseContext)
        {
            Guard.ArgumentNotNull(databaseContext, nameof(databaseContext));

            _cities = databaseContext.Cities;
        }

        public async Task Add(CityEntity entity)
        {
            await _cities.InsertOneAsync(entity).ConfigureAwait(false);
        }

        public async Task<ICollection<CityEntity>> Get()
        {
            var cities = await _cities.FindAsync(x => true).ConfigureAwait(false);

            return cities.ToList();
        }


        public async Task<CityEntity> GetById(Guid id)
        {
            var city = await _cities.FindAsync(x => x.Id == id).ConfigureAwait(false);

            return city.FirstOrDefault();
        }

        public async Task<CityEntity> GetByName(string name)
        {
            var city = await _cities.FindAsync(x => x.Name == name).ConfigureAwait(false);

            return city.FirstOrDefault();
        }

        public async Task Update(CityEntity entity)
        {
            await _cities.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity).ConfigureAwait(false);
        }
    }
}
