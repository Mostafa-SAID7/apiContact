using apiContact.Models.Dtos;
using apiContact.Models.Entity;

namespace apiContact.Services
{
    public class FeatureService : IFeatureService
    {
        // In-memory list of features (simulate database)
        private readonly List<FeatureCard> _features = new()
        {
            new FeatureCard
            {
                Id = 1,
                Title = "Fast Performance",
                Description = "Experience blazing fast load times and smooth interactions across all devices.",
                Color = "indigo"
            },
            new FeatureCard
            {
                Id = 2,
                Title = "Responsive Design",
                Description = "Looks perfect on mobile, tablet, and desktop thanks to Tailwind's responsive utilities.",
                Color = "green"
            },
            new FeatureCard
            {
                Id = 3,
                Title = "Modern UI",
                Description = "Beautiful card designs with shadows, hover effects, and smooth transitions.",
                Color = "yellow"
            },
            new FeatureCard
            {
                Id = 4,
                Title = "Customizable",
                Description = "Easily adapt the layout, colors, and content using Tailwind's utility classes.",
                Color = "purple"
            },
            new FeatureCard
            {
                Id = 5,
                Title = "Scalable",
                Description = "Perfect for projects of any size — from small demos to large-scale applications.",
                Color = "pink"
            },
            new FeatureCard
            {
                Id = 6,
                Title = "Developer Friendly",
                Description = "Clean code structure, reusable components, and Tailwind CSS for rapid development.",
                Color = "teal"
            }
        };

        public async Task<List<FeatureCard>> GetAllFeaturesAsync()
        {
            // simulate async work
            await Task.Delay(50);
            return _features;
        }

        public async Task<FeatureCard?> GetFeatureByIdAsync(int id)
        {
            await Task.Delay(20); // simulate async
            return _features.FirstOrDefault(f => f.Id == id);
        }

        public async Task TrackInteractionAsync(int featureId, FeatureTrackingRequest request)
        {
            await Task.Delay(10); // simulate async

            var feature = _features.FirstOrDefault(f => f.Id == featureId);
            if (feature == null)
                throw new KeyNotFoundException($"Feature with id {featureId} not found.");

            // For now, just log to console — later can store in DB
            Console.WriteLine($"[Interaction] Feature {feature.Title} ({featureId}) was interacted with by User {request.UserId}. Action: {request.Action}");
        }
    }
}
