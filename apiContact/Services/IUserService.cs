using apiContact.Models.Entity;

namespace apiContact.Services
{
    public interface IUserService
    {
        Task<UserProfile?> GetUserProfileAsync(int userId);
    }
}
