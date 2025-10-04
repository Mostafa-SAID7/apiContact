using apiContact.Models.Dtos;
using apiContact.Models.Entity;

namespace apiContact.Services
{
    public interface IFeatureService
    {
        Task<List<FeatureCard>> GetAllFeaturesAsync();
        Task<FeatureCard?> GetFeatureByIdAsync(int id);
        Task TrackInteractionAsync(int featureId, FeatureTrackingRequest request);
    }
}
