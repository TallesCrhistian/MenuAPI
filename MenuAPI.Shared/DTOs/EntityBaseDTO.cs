namespace MenuAPI.Shared.DTOs
{
    public class EntityBaseDTO
    {
        public Guid Id { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
