using MenuAPI.Shared.ViewModels.Adress;

namespace MenuAPI.Shared.ViewModels.Enterprise
{
    public class EnterpriseViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CNPJ { get; set; }

        public string SocialReason { get; set; }

        public AdressViewModel AdressViewModel { get; set; }
    }
}
