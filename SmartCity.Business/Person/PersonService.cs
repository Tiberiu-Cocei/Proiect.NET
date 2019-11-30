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
        private readonly IPersonRepository Repository;

        public PersonService(IPersonRepository repository)
        {
            Guard.ArgumentNotNull(repository, nameof(repository));

            Repository = repository;
        }
        public Task AddAsync(PersonEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PersonEntity>> GetAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<PersonEntity> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PersonEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
