using SmartCity.Domain.Entities;
using System.Threading.Tasks;

namespace SmartCity.DataAccess.Repositories.City
{
    public interface ICityRepository: IBaseRepository<CityEntity>
    {
        Task<CityEntity> GetByName(string name);
    }
}
