using MenuAPI.Shared.Enumerators;

namespace MenuAPI.Entites
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public double Value { get; set; }

        public string Description { get; set; }

        public string UrlImage { get; set; }

        public GroupEnum Group { get; set; }

        public Guid EnterpriseId { get; set; }

        public Enterprise Enterprise { get; set; }
    }
}
