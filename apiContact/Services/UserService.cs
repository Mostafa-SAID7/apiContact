using apiContact.Models.Entity;

namespace apiContact.Services
{
    public class UserService : IUserService
    {
        public async Task<UserProfile?> GetUserProfileAsync(int userId)
        {
            // Simulate async database call
            await Task.Delay(100);

            // Mock user data
            return new UserProfile
            {
                Id = userId,
                Name = "John Doe",
                Email = "john.doe@example.com",
                AvatarUrl = null
            };
        }
    }
}
