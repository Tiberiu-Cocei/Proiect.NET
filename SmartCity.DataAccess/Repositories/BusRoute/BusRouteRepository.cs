using MongoDB.Driver;
using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.DataAccess.Repositories.BusRoute
{
    public class BusRouteRepository : IBusRouteRepository
    {
        private readonly IMongoCollection<BusRouteEntity> _busRoute;
        
        public BusRouteRepository(DatabaseContext databaseContext)
        {
            Guard.ArgumentNotNull(databaseContext, nameof(databaseContext));

            _busRoute = databaseContext.BusRoutes;
        }
        public async Task Add(BusRouteEntity entity)
        {
            await _busRoute.InsertOneAsync(entity).ConfigureAwait(false);
        }

        public async Task Delete(Guid id)
        {
            await _busRoute.DeleteOneAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<ICollection<BusRouteEntity>> Get()
        {
            var busRoutes = await _busRoute.FindAsync(x => true).ConfigureAwait(false);

            return busRoutes.ToList();
        }

        public async Task<BusRouteEntity> GetById(Guid id)
        {
            var busStations = await _busRoute.FindAsync(x => x.Id == id).ConfigureAwait(false);

            return busStations.FirstOrDefault();
        }

        public async Task Update(BusRouteEntity entity)
        {
            await _busRoute.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity).ConfigureAwait(false);
        }
    }
}
