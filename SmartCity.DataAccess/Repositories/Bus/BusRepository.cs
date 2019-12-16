using MongoDB.Driver;
using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.DataAccess.Repositories.Bus
{
    public class BusRepository : IBusRepository
    {
        private readonly IMongoCollection<BusEntity> _buses;

        public BusRepository(DatabaseContext databaseContext)
        {
            Guard.ArgumentNotNull(databaseContext, nameof(databaseContext));

            _buses = databaseContext.Buses;
        }

        public async Task Add(BusEntity entity)
        {
            await _buses.InsertOneAsync(entity).ConfigureAwait(false);
        }

        public async Task<ICollection<BusEntity>> Get()
        {
            var buses = await _buses.FindAsync(x => true).ConfigureAwait(false);

            return buses.ToList();
        }

        public async Task<BusEntity> GetById(Guid id)
        {
            var bus = await _buses.FindAsync(x => x.Id == id).ConfigureAwait(false);

            return bus.FirstOrDefault();
        }

        public async Task Update(BusEntity entity)
        {
            await _buses.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity).ConfigureAwait(false);
        }

        public async Task Delete(Guid id)
        {
            await _buses.DeleteOneAsync(x => x.Id == id).ConfigureAwait(false);
        }
    }
}
