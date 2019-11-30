using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using SmartCity.Domain.Entities;
using Vanguard;

namespace SmartCity.DataAccess.Repositories.Person
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMongoCollection<PersonEntity> persons;

        public PersonRepository(DatabaseContext databaseContext)
        {
            Guard.ArgumentNotNull(databaseContext, nameof(databaseContext));

            persons = databaseContext.Persons;
        }

        public Task Add(PersonEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PersonEntity>> Get(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<PersonEntity> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(PersonEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
