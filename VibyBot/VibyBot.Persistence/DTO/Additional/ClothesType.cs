using System;

namespace VibyBot.Persistence.DTO.Additional
{
    public class ClothesType : IEquatable<ClothesType>
    {
        public string Type;

        public static ClothesType Tshirt { get => new ClothesType() { Type = _Tshirt}; }
        public static ClothesType Cap {get => new ClothesType() { Type = _Cap}; }
        public static ClothesType Polo { get => new ClothesType() { Type = _Polo }; }

        private const string _Tshirt = "футболка";
        private const string _Cap = "кепка";
        private const string _Polo = "поло";

        public ClothesType(){ }

        public bool Equals(ClothesType other)
        {
            return other.Type.Equals(Type);
        }
    }
}
