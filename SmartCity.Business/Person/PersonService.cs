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

        public async Task<ICollection<PersonEntity>> GetAsync()
        {
            return await _repository.Get().ConfigureAwait(false);
        }

        public async Task<PersonEntity> GetByCredentials(string username, string password)
        {
            Guard.ArgumentNotNull(username, nameof(username));
            Guard.ArgumentNotNull(password, nameof(password));

            return await _repository.GetPersonByCredentials(username, password).ConfigureAwait(false);
        }

        public async Task<PersonEntity> GetByEmail(string email)
        {
            Guard.ArgumentNotNull(email, nameof(email));

            return await _repository.GetByEmail(email).ConfigureAwait(false);
        }

        public async Task<PersonEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetById(id).ConfigureAwait(false);
        }

        public async Task<PersonEntity> GetByUsername(string username)
        {
            Guard.ArgumentNotNull(username, nameof(username));

            return await _repository.GetByUsername(username).ConfigureAwait(false);
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
