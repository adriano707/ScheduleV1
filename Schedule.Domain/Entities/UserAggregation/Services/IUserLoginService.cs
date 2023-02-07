namespace Schedule.Domain.Entities.UserAggregation.Services
{
    public interface IUserLoginService
    {
        Task<User> Login(string user, string password);
    }
}
