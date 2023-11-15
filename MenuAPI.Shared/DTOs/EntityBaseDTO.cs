namespace MenuAPI.Shared.DTOs
{
    public class EntityBaseDTO
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
