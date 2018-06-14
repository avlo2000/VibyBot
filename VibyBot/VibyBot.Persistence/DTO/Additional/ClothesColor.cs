using System;
using System.Collections.Generic;

namespace VibyBot.Persistence.DTO.Additional
{
    public class ClothesColor : IEquatable<ClothesColor>
    {
        public string Color;

        public static ClothesColor Black { get => new ClothesColor() { Color = _black }; }
        public static ClothesColor White { get => new ClothesColor() { Color = _white }; }
        public static ClothesColor Yellow { get => new ClothesColor() { Color = _yellow }; }

        private const string _black = "чорний";
        private const string _white = "білий";
        private const string _yellow = "жовтий";

        public ClothesColor() { }

        public bool Equals(ClothesColor other)
        {
            return other.Color.Equals(Color);
        }

        public override int GetHashCode()
        {
            return -1200350280 + EqualityComparer<string>.Default.GetHashCode(Color);
        }
    }
}
