using MongoDB.Driver;
using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.DataAccess.Repositories.PointOfInterest
{
    public class PointOfInterestRepository : IPointOfInterestRepository
    {
        private readonly IMongoCollection<PointOfInterestEntity> _pointOfInterests;

        public PointOfInterestRepository(DatabaseContext databaseContext)
        {
            Guard.ArgumentNotNull(databaseContext, nameof(databaseContext));

            _pointOfInterests = databaseContext.PointOfInterests;
        }

        public async Task Add(PointOfInterestEntity entity)
        {
            await _pointOfInterests.InsertOneAsync(entity).ConfigureAwait(false);
        }

        public async Task<ICollection<PointOfInterestEntity>> Get()
        {
            var pointOfInterests = await _pointOfInterests.FindAsync(x => true).ConfigureAwait(false);

            return pointOfInterests.ToList();
        }

        public async Task<PointOfInterestEntity> GetByCoordonates(CoordinatesEntity coordinate)
        {
            var pointOfInterest = await _pointOfInterests.FindAsync(x => x.Coordinates == coordinate).ConfigureAwait(false);

            return pointOfInterest.FirstOrDefault();
        }

        public async Task<PointOfInterestEntity> GetById(Guid id)
        {
            var pointOfInterest = await _pointOfInterests.FindAsync(x => x.Id == id).ConfigureAwait(false);

            return pointOfInterest.FirstOrDefault();
        }

        public async Task<ICollection<PointOfInterestEntity>> GetByPersonId(Guid personId)
        {
            var pointOfInterest = await _pointOfInterests.FindAsync(x => x.PersonId == personId).ConfigureAwait(false);

            return pointOfInterest.ToList();
        }

        public async Task Update(PointOfInterestEntity entity)
        {
            await _pointOfInterests.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity).ConfigureAwait(false);
        }

        public async Task Delete(Guid id)
        {
            await _pointOfInterests.DeleteOneAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<ICollection<PointOfInterestEntity>> GetByCityName(string cityName)
        {
            var response = await _pointOfInterests.FindAsync(x => x.CityName == cityName).ConfigureAwait(false);

            return response.ToList();
        }
    }
}
