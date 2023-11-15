using MenuAPI.Shared.Enumerators;
using MenuAPI.Shared.ViewModels.Enterprise;

namespace MenuAPI.Shared.ViewModels.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Value { get; set; }

        public string Description { get; set; }

        public string UrlImage { get; set; }

        public GroupEnum Group { get; set; }

        public EnterpriseViewModel EnterpriseViewModel { get; set; }
    }
}
