using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartCity.DataAccess.Repositories.Person
{
    public interface IPersonRepository : IBaseRepository<PersonEntity>
    {
        Task<PersonEntity> GetPersonByCredentials(string username, string password);
        Task<PersonEntity> GetByUsername(string username);
        Task<PersonEntity> GetByEmail(string email);
    }
}
