using SmartCity.DataAccess.Repositories.Person;
using SmartCity.Domain.Entities;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.Business.General
{
    public class UserCheckService : IUserCheckService
    {
        private readonly IPersonRepository _repository;
        public UserCheckService(IPersonRepository repository)
        {
            Guard.ArgumentNotNull(repository, nameof(repository));

            _repository = repository;
        }
        public async Task<PersonEntity> GetByEmail(string email)
        {
            Guard.ArgumentNotNull(email, nameof(email));

            return await _repository.GetByEmail(email).ConfigureAwait(false);
        }

        public async Task<PersonEntity> GetByUsername(string username)
        {
            Guard.ArgumentNotNull(username, nameof(username));

            return await _repository.GetByUsername(username).ConfigureAwait(false);
        }
    }
}
