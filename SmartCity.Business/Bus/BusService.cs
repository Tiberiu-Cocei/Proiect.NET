using SmartCity.DataAccess.Repositories.Bus;
using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.Business.Bus
{
    public class BusService: IBusService
    {
        private readonly IBusRepository _repository;

        public BusService(IBusRepository repository)
        {
            Guard.ArgumentNotNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task AddAsync(BusEntity entity)
        {
            Guard.ArgumentNotNull(entity, nameof(entity));

            await _repository.Add(entity).ConfigureAwait(false);
        }

        public async Task<ICollection<BusEntity>> GetAsync()
        {
            return await _repository.Get().ConfigureAwait(false);
        }

        public async Task<BusEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetById(id).ConfigureAwait(false);
        }

        public async Task UpdateAsync(BusEntity bus)
        {
            Guard.ArgumentNotNull(bus, nameof(bus));

            var insertedBus = await _repository.GetById(bus.Id).ConfigureAwait(false);
            if (insertedBus != null)
            {
                await _repository.Update(bus).ConfigureAwait(false);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var bus = await _repository.GetById(id).ConfigureAwait(false);
            if (bus != null)
            {
                await _repository.Delete(id).ConfigureAwait(false);
            }
        }
    }
}
