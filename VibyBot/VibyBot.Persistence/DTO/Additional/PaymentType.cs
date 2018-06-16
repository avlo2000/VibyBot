using System;
using System.Collections.Generic;

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

        public override int GetHashCode()
        {
            return 2049151605 + EqualityComparer<string>.Default.GetHashCode(Type);
        }
    }
}
