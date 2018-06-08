using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Control.Exceptions;
using VibyBot.Control.ManagerConfiguration;

namespace VibyBot.Control.DTO
{
    public class Order
    {
        //поля мають заповнюватися в тому порядку в якому вони написані
        public ClothesType Type { get; set; }

        private string _print;
        public string Print
        {
            get => _print;
            set
            {
                _print = null;
                foreach (var print in PrintList.Prints)
                    if (value == print)
                        _print = value;
                if (_print == null)
                    throw new UnexistingPrintException();
            }
        }

        private string _color;
        public string Color
        {
            get => _color;
            set
            {
                if (Type == ClothesType.Tshirt)
                    _color = value;
                else
                    throw new NotTshirtColorException();
            }
        }

        public string Name { get; set; }

        public string Adress { get; set; }

        //потім в MessageProcessing якщо користувач введе Львів тоді це встановимо у Cash
        public PaymentType Payment { get; set; }

        public string CardNumber { get; private set; }

        public Order()
        {
            CardNumber = ManagerConfiguration.CardNumber.Number;
        }
    }
}
