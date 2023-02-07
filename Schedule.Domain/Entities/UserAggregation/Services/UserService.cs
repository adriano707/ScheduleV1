using Schedule.Domain.Repositories;

namespace Schedule.Domain.Entities.UserAggregation.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> GetUserById(Guid id)
        {
            return _repository.Query<User>().FirstOrDefault(u => u.Id == id.ToString());
        }

        public async Task<List<User>> GetAllUser()
        {
            return _repository.Query<User>().ToList();
        }
    }
}
