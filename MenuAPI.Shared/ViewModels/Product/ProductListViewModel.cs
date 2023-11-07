using MenuAPI.Shared.Enumerators;

namespace MenuAPI.Shared.ViewModels.Product
{
    public class ProductListViewModel
    {
        public string Name { get; set; }

        public double Value { get; set; }

        public string Description { get; set; }

        public GroupEnum Group { get; set; }

        public Guid EnterpriseId { get; set; }
    }
}
