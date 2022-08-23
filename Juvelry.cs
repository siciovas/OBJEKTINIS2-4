using System;

namespace LD4.Polimorfizmas
{
    public abstract class Juvelry : IComparable<Juvelry>, IEquatable<Juvelry>
    {
        public char Type { get; private set; }
        public string Made { get; private set; }
        public string Name { get; private set; }
        public string Metal { get; private set; }
        public int Weight { get; private set; }
        public int Purity { get; private set; }
        public decimal Price { get; private set; }

        public Juvelry(char type, string made, string name, string metal, int weight, int purity, decimal price)
        {
            this.Type = type;
            this.Made = made;
            this.Name = name;
            this.Metal = metal;
            this.Weight = weight;
            this.Purity = purity;
            this.Price = price;
        }

        public abstract int CompareTo(Juvelry other);

        public abstract bool Equals(Juvelry other);

        public abstract override string ToString();

        public abstract bool IsExpensive();
    }
}