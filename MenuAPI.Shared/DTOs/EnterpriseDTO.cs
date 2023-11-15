namespace MenuAPI.Shared.DTOs
{
    public class EnterpriseDTO : EntityBaseDTO
    {
        public string Name { get; set; }

        public string CNPJ { get; set; }

        public string SocialReason { get; set; }

        public Guid AdressId { get; set; }

        public List<ProductDTO> ProductsDTO { get; set; }

        public AdressDTO AdressDTO { get; set; }
    }
}
