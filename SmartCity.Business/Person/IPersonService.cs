using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartCity.Business.Person
{
    public interface IPersonService
    {
        Task<ICollection<PersonEntity>> GetAsync(Guid userId);

        Task<PersonEntity> GetByIdAsync(Guid id);

        Task AddAsync(PersonEntity entity);

        Task UpdateAsync(PersonEntity entity);
    }
}
