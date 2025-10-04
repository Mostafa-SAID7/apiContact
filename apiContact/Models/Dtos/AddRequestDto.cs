namespace apiContact.Models.Dtos
{
    public class AddRequestDto
    {
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string Phone { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
