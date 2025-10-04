using apiContact.Models.Dtos;
using apiContact.Models.Entity;
using apiContact.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiContact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly ILogger<FeaturesController> _logger;

        public FeaturesController(IFeatureService featureService, ILogger<FeaturesController> logger)
        {
            _featureService = featureService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<FeatureCard>>>> GetFeatures()
        {
            try
            {
                var features = await _featureService.GetAllFeaturesAsync();

                return Ok(new ApiResponse<List<FeatureCard>>
                {
                    Data = features,
                    Success = true,
                    Message = "Features retrieved successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving features");

                return StatusCode(500, new ApiResponse<List<FeatureCard>>
                {
                    Data = null,
                    Success = false,
                    Message = "An error occurred while retrieving features"
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<FeatureCard>>> GetFeature(int id)
        {
            try
            {
                var feature = await _featureService.GetFeatureByIdAsync(id);

                if (feature == null)
                {
                    return NotFound(new ApiResponse<FeatureCard>
                    {
                        Data = null,
                        Success = false,
                        Message = $"Feature with ID {id} not found"
                    });
                }

                return Ok(new ApiResponse<FeatureCard>
                {
                    Data = feature,
                    Success = true,
                    Message = "Feature retrieved successfully"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving feature {Id}", id);

                return StatusCode(500, new ApiResponse<FeatureCard>
                {
                    Data = null,
                    Success = false,
                    Message = "An error occurred while retrieving the feature"
                });
            }
        }

        [HttpPost("{id}/track")]
        public async Task<ActionResult<ApiResponse<string>>> TrackFeatureInteraction(
            int id,
            [FromBody] FeatureTrackingRequest request)
        {
            try
            {
                await _featureService.TrackInteractionAsync(id, request);

                _logger.LogInformation(
                    "Feature {FeatureId} interaction tracked: {Action} at {Timestamp}",
                    id,
                    request.Action,
                    request.Timestamp);

                return Ok(new ApiResponse<string>
                {
                    Data = "Tracked successfully",
                    Success = true,
                    Message = "Feature interaction tracked"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error tracking feature {Id} interaction", id);

                return StatusCode(500, new ApiResponse<string>
                {
                    Data = null,
                    Success = false,
                    Message = "An error occurred while tracking the interaction"
                });
            }
        }
    }
}
