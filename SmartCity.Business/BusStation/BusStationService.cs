using SmartCity.DataAccess.Repositories.BusStation;
using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.Business.BusStation
{
    public class BusStationService : IBusStationService
    {
        private readonly IBusStationRepository _repository;

        public BusStationService(IBusStationRepository repository)
        {
            Guard.ArgumentNotNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task AddAsync(BusStationEntity entity)
        {
            Guard.ArgumentNotNull(entity, nameof(entity));

            await _repository.Add(entity).ConfigureAwait(false);
        }

        public async Task<ICollection<BusStationEntity>> GetAsync()
        {
            return await _repository.Get().ConfigureAwait(false);
        }

        public async Task<BusStationEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetById(id).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var busStation = await _repository.GetById(id).ConfigureAwait(false);
            if (busStation != null)
            {
                await _repository.Delete(id).ConfigureAwait(false);
            }
        }

        public async Task UpdateAsync(BusStationEntity busStation)
        {
            Guard.ArgumentNotNull(busStation, nameof(busStation));

            var busRoutes = await _repository.GetById(busStation.Id).ConfigureAwait(false);
            if (busRoutes != null)
            {
                await _repository.Update(busStation).ConfigureAwait(false);
            }
        }
    }
}
