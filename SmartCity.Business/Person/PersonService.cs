using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartCity.DataAccess.Repositories.Person;
using SmartCity.Domain.Entities;
using Vanguard;

namespace SmartCity.Business.Person
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            Guard.ArgumentNotNull(repository, nameof(repository));

            _repository = repository;
        }
        public async Task AddAsync(PersonEntity entity)
        {
            Guard.ArgumentNotNull(entity, nameof(entity));

            await _repository.Add(entity).ConfigureAwait(false);
        }

        public async Task<ICollection<PersonEntity>> GetAsync(Guid userId)
        {
            return await _repository.Get(userId).ConfigureAwait(false);
        }

        public async Task<PersonEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetById(id).ConfigureAwait(false);
        }

        public async Task UpdateAsync(PersonEntity entity)
        {
            
            Guard.ArgumentNotNull(entity, nameof(entity));
            var insertedPerson = await _repository.GetById(entity.Id).ConfigureAwait(false);
            if( insertedPerson != null)
            {
                await _repository.Update(entity).ConfigureAwait(false);
            }
        }
    }
}
