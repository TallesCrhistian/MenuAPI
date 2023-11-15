namespace MenuAPI.Shared.DTOs
{
    public class AdressDTO : EntityBaseDTO
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public EnterpriseDTO EnterpriseDTO { get; set; }
    }
}
