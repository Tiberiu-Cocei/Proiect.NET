using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartCity.DataAccess
{
    public interface IBaseRepository<TEntity>
    {
        Task<ICollection<TEntity>> Get();

        Task<TEntity> GetById(Guid id);

        Task Add(TEntity entity);

        Task Update(TEntity entity);
    }
}
