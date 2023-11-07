namespace MenuAPI.Entites
{
    public class Adress : EntityBase
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public Enterprise Enterprise { get; set; }
    }
}
