using SmartCity.Domain.Entities;
using System.Threading.Tasks;

namespace SmartCity.Business.General
{
    public interface IUserCheckService
    {
        Task<PersonEntity> GetByUsername(string username);

        Task<PersonEntity> GetByEmail(string email);
    }
}
