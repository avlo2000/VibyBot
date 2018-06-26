using VibyBot.Persistence.DTO.Additional;

namespace VibyBot.Persistence.DTO
{
    public class Order
    { 
        public long OrderId { get; set; }

        public long ClientId { get; private set; }

        public ClothesType ClothesType { get; set; }

        public string Print { get; set; }

        public ClothesColor ClothesColor { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Adress { get; set; }

        public PaymentType Payment { get; set; }

        public bool Ready { get; set; }

        public Order(long id)
        {
            ClientId = id;
            Ready = false;
        }
    }
}
