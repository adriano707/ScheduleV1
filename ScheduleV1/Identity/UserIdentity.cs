using Schedule.Domain;

namespace Schedule.API.V1.Identity
{
    public class UserIdentity : IUserIdentity
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public string UserName
        {
            get
            {
                var userName = _contextAccessor.HttpContext.User.Identity.Name;

                return userName;
            }
        }

        public UserIdentity(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
    }
}
