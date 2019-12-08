using SmartCity.DataAccess.Repositories.BusRoute;
using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.Business.BusRoute
{
    public class BusRouteService : IBusRouteService
    {
        private readonly IBusRouteRepository _repository;

        public BusRouteService(IBusRouteRepository repository)
        {
            Guard.ArgumentNotNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task AddAsync(BusRouteEntity entity)
        {
            Guard.ArgumentNotNull(entity, nameof(entity));

            await _repository.Add(entity).ConfigureAwait(false);
        }

        public async Task<ICollection<BusRouteEntity>> GetAsync()
        {
            return await _repository.Get().ConfigureAwait(false);
        }

        public async Task<BusRouteEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetById(id).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var busRoute = await _repository.GetById(id).ConfigureAwait(false);
            if (busRoute != null)
            {
                await _repository.Delete(id).ConfigureAwait(false);
            }
        }

        public async Task UpdateAsync(BusRouteEntity busRoute)
        {
            Guard.ArgumentNotNull(busRoute, nameof(busRoute));

            var busRoutes = await _repository.GetById(busRoute.Id).ConfigureAwait(false);
            if (busRoutes != null)
            {
                await _repository.Update(busRoute).ConfigureAwait(false);
            }
        }
    }
}
