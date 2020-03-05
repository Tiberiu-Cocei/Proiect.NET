using MongoDB.Driver;
using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.DataAccess.Repositories.Person
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMongoCollection<PersonEntity> _persons;

        public PersonRepository(DatabaseContext databaseContext)
        {
            Guard.ArgumentNotNull(databaseContext, nameof(databaseContext));

            _persons = databaseContext.Persons;
        }

        public async Task Add(PersonEntity entity)
        {
            await _persons.InsertOneAsync(entity).ConfigureAwait(false);
        }

        public async Task<ICollection<PersonEntity>> Get()
        {
            var persons = await _persons.FindAsync(x => true).ConfigureAwait(false);

            return persons.ToList();
        }

        public async Task<PersonEntity> GetById(Guid id)
        {
            var person = await _persons.FindAsync(x => x.Id == id).ConfigureAwait(false);

            return person.FirstOrDefault();
        }

        public async Task<PersonEntity> GetPersonByCredentials(string username, string password)
        {
            var person = await _persons.FindAsync(x => x.Username == username).ConfigureAwait(false);
            var result = person.FirstOrDefault();

            if(result == null || result.Password != password)
            {
                return null;
            }

            return result;
        }

        public async Task<PersonEntity> GetByEmail(string email)
        {
            var person = await _persons.FindAsync(x => x.Email == email).ConfigureAwait(false);

            return person.FirstOrDefault();
        }

        public async Task<PersonEntity> GetByUsername(string username)
        {
            var person = await _persons.FindAsync(x => x.Username == username).ConfigureAwait(false);

            return person.FirstOrDefault();
        }

        public async Task Update(PersonEntity entity)
        {
            await _persons.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity).ConfigureAwait(false);
        }
    }
}
