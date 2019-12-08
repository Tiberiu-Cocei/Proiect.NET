using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartCity.DataAccess.Repositories.Bus
{
    public interface IBusRepository : IBaseRepository<BusEntity>
    {
        Task Delete(Guid id);
    }
}
