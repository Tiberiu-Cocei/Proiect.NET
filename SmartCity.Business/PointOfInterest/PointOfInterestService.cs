using SmartCity.DataAccess.Repositories.PointOfInterest;
using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.Business.PointOfInterest
{
    public class PointOfInterestService : IPointOfInterestService
    {
        private readonly IPointOfInterestRepository _repository;

        public PointOfInterestService(IPointOfInterestRepository repository)
        {
            Guard.ArgumentNotNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task AddAsync(PointOfInterestEntity entity)
        {
            Guard.ArgumentNotNull(entity, nameof(entity));

            await _repository.Add(entity).ConfigureAwait(false);
        }

        public async Task<ICollection<PointOfInterestEntity>> GetAsync()
        {
            return await _repository.Get().ConfigureAwait(false);
        }

        public async Task<PointOfInterestEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetById(id).ConfigureAwait(false);
        }

        public async Task<ICollection<PointOfInterestEntity>> GetByPersonIdAsync(Guid personId)
        {
            return await _repository.GetByPersonId(personId).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var pointOfInterest = await _repository.GetById(id).ConfigureAwait(false);
            if (pointOfInterest != null)
            {
                await _repository.Delete(id).ConfigureAwait(false);
            }
        }

        public async Task UpdateAsync(PointOfInterestEntity pointOfInterest)
        {
            Guard.ArgumentNotNull(pointOfInterest, nameof(pointOfInterest));

            var insertedPointOfInterest = await _repository.GetById(pointOfInterest.Id).ConfigureAwait(false);
            if (insertedPointOfInterest != null)
            {
                await _repository.Update(pointOfInterest).ConfigureAwait(false);
            }
        }

        public async Task<ICollection<PointOfInterestEntity>> GetByCityName(string cityName)
        {
            Guard.ArgumentNotNull(cityName, nameof(cityName));

            return await _repository.GetByCityName(cityName).ConfigureAwait(false);
        }
    }
}
