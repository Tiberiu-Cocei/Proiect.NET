using MongoDB.Driver;
using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.DataAccess.Repositories.BusStation
{
    public class BusStationRepository : IBusStationRepository
    {
        public readonly IMongoCollection<BusStationEntity> _busStaions;

        public BusStationRepository(DatabaseContext databaseContext)
        {
            Guard.ArgumentNotNull(databaseContext, nameof(databaseContext));

            _busStaions = databaseContext.BusStations;
        }

        public async Task Add(BusStationEntity entity)
        {
            await _busStaions.InsertOneAsync(entity).ConfigureAwait(false);
        }

        public async Task Delete(Guid id)
        {
            await _busStaions.DeleteOneAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<ICollection<BusStationEntity>> Get()
        {
            var busStations = await _busStaions.FindAsync(x => true).ConfigureAwait(false);

            return busStations.ToList();
        }

        public async Task<BusStationEntity> GetByCoordonates(CoordinatesEntity coordinates)
        {
            var busStations = await _busStaions.FindAsync(x => x.Coordinates == coordinates).ConfigureAwait(false);

            return busStations.FirstOrDefault();
        }

        public async Task<BusStationEntity> GetById(Guid id)
        {
            var busStations = await _busStaions.FindAsync(x => x.Id == id).ConfigureAwait(false);

            return busStations.FirstOrDefault();
        }

        public async Task Update(BusStationEntity entity)
        {
            await _busStaions.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity).ConfigureAwait(false);
        }
    }
}
