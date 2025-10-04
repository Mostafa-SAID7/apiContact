namespace apiContact.Models.Dtos
{
    public class FeatureTrackingRequest
    {
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Action { get; set; }
    }
}
