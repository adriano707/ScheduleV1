using Schedule.Domain.Entities.UserAggregation;

namespace Schedule.Domain.Entities.UserAggregation.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(Guid id);
        Task<List<User>> GetAllUser();
    }
}
