namespace MenuAPI.Entites
{
    public class Enterprise : EntityBase
    {
        public string Name { get; set; }

        public string CNPJ { get; set; }

        public string SocialReason { get; set; }

        public Guid AdressId { get; set; }

        public List<Product> Products { get; set; }

        public Adress Adress { get; set; }
    }
}
