using System;
using VibyBot.Persistence.DTO.Additional;
using VibyBot.Persistence.Exceptions;
using VibyBot.Persistence.ManagerConfiguration;

namespace VibyBot.Persistence.DTO
{
    public class Order
    {
        public override string ToString()
        {
            string stringOrder = "";
            if (Ready)
            {
                stringOrder = "Замовлення у VIBY shop " + Environment.NewLine;
                stringOrder += "Користувач: " + Name + Environment.NewLine;
                stringOrder += "Тип одягу: " + ClothesType.Type + Environment.NewLine;
                stringOrder += "Колір одягу: " + ClothesColor.Color + Environment.NewLine;
                stringOrder += "Адресса: " + Adress + Environment.NewLine;
                stringOrder += "Споіб оплати: " + Payment.Type + Environment.NewLine;
            }
            return stringOrder;
        }

        //поля мають заповнюватися в тому порядку в якому вони написані
        public long ClientId { get; private set; }

        public ClothesType ClothesType { get; set; }

        private string _print;
        public string Print
        {
            get => _print;
            set
            {
                _print = null;
                foreach (var print in ManagerConfig.Prints)
                    if (value == print)
                        _print = value;
                if (_print == null)
                    throw new NotExistingPrintException();
            }
        }

        public ClothesColor ClothesColor { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        //потім в MessageProcessing якщо користувач введе Львів тоді це встановимо у Cash
        public PaymentType Payment { get; set; }

        public string CardNumber { get; private set; }

        public bool Ready { get; set; }

        public Order(long id)
        {
            CardNumber = ManagerConfig.CardNumber;
            ClientId = id;
            Ready = false;
        }
    }
}
