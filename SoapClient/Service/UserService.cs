using WebApi.Models;

namespace WebApi.Service
{
    public class UserService : IUserService
    {
        public string RegisterUser(User user)
        {
            if (IsValid(user))
            {
                return $"User {user.EmailAddress} registered!";
            }
            return "Cannot register user.";
        }

        private bool IsValid(User user)
        {
            return user != null && !string.IsNullOrEmpty(user.EmailAddress);
        }
    }
}