namespace MenuAPI.Shared.ViewModels.Enterprise
{
    public class EnterpriseCreateViewModel
    {
        public string Name { get; set; }

        public string CNPJ { get; set; }

        public string SocialReason { get; set; }

        public Guid AdressId { get; set; }
    }
}
