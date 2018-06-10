﻿using VibyBot.Persistence.DTO.Additional;
using VibyBot.Persistence.Exceptions;
using VibyBot.Persistence.ManagerConfiguration;

namespace VibyBot.Persistence.DTO
{
    public class Order
    {
        //поля мають заповнюватися в тому порядку в якому вони написані
        public int ClientId { get; private set; }

        public ClothesType Type { get; set; }

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

        private ClothesColor _color;
        public ClothesColor Color
        {
            get => _color;
            set
            {
                if (Type == ClothesType.Tshirt)
                    _color = value;
                else if (Type == ClothesType.Polo && value == ClothesColor.Yellow)
                    throw new WrongColorException();
                else if (Type == ClothesType.Polo && value != ClothesColor.Yellow)
                    _color = value;
                else if (Type == ClothesType.Cap && (value == ClothesColor.Yellow || value == ClothesColor.White))
                    throw new WrongColorException();
                else if (Type == ClothesType.Cap && value == ClothesColor.Black)
                    _color = value;
            }
        }

        public string Name { get; set; }

        public string Adress { get; set; }

        //потім в MessageProcessing якщо користувач введе Львів тоді це встановимо у Cash
        public PaymentType Payment { get; set; }

        public string CardNumber { get; private set; }

        public bool Ready { get; set; }

        public Order(int id)
        {
            CardNumber = ManagerConfig.CardNumber;
            ClientId = id;
            Ready = false;
        }
    }
}