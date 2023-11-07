namespace MenuAPI.Entites
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
