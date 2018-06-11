using System;
using VibyBot.Persistence.DTO.Additional;

namespace VibyBot.Persistence.DTO
{
    public class Order
    { 
        //поля мають заповнюватися в тому порядку в якому вони написані
        public long ClientId { get; private set; }

        public ClothesType ClothesType { get; set; }

        public string Print;

        public ClothesColor ClothesColor { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        //потім в MessageProcessing якщо користувач введе Львів тоді це встановимо у Cash
        public PaymentType Payment { get; set; }

        public bool Ready { get; set; }

        public Order(long id)
        {
            ClientId = id;
            Ready = false;
        }
    }
}
