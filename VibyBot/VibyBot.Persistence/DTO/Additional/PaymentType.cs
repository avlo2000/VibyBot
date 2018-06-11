using System;

namespace VibyBot.Persistence.DTO.Additional
{
    public class PaymentType : IEquatable<PaymentType>
    {
        public string Type;

        public static PaymentType Cash { get => new PaymentType() { Type = _cash }; }
        public static PaymentType CreditCard { get => new PaymentType() { Type = _creditCard }; }

        private const string _cash = "готівкою";
        private const string _creditCard = "кредитною карткою";

        public PaymentType() { }

        public bool Equals(PaymentType other)
        {
            return other.Type.Equals(Type);
        }
    }
}
