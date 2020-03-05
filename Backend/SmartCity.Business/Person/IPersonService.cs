using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartCity.Business.Person
{
    public interface IPersonService
    {
        Task<ICollection<PersonEntity>> GetAsync();

        Task<PersonEntity> GetByIdAsync(Guid id);

        Task<PersonEntity> GetByCredentials(string username, string password);

        Task<PersonEntity> GetByUsername(string username);

        Task<PersonEntity> GetByEmail(string email);

        Task AddAsync(PersonEntity entity);

        Task UpdateAsync(PersonEntity entity);
    }
}
