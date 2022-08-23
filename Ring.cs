using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD4.Polimorfizmas
{
    public class Ring : Juvelry
    {
        public int Size { get; private set; }

        public Ring(char type, string made, string name, string metal, int weight, int purity, decimal price, int size) 
            : base(type,made,name,metal,weight,purity,price)
        {
            this.Size = size;
        }

        public override int CompareTo(Juvelry other)
        {
            Ring ring = other as Ring;
            if (ring is null) return 0;
            return this.Size.CompareTo(ring.Size);
        }

        public override bool Equals(Juvelry other)
        {
            Ring ring = other as Ring;
            if (ring is null) return false;
            return this.Type.Equals(ring.Type) && this.Made.Equals(ring.Made) && this.Name.Equals(ring.Name)
                && this.Metal.Equals(ring.Metal) && this.Weight.Equals(ring.Weight) && this.Purity.Equals(ring.Purity)
                && this.Price.Equals(ring.Price) && this.Size.Equals(ring.Size);
        }
        public override string ToString()
        {
            return string.Format(" {0} ; {1} ; {2} ; {3} ; {4} ; {5} ; {6} ; {7} |", Type, Made, Name, Metal, Weight,
                Purity, Price, Size);
        }

        public override bool IsExpensive()
        {
            Ring ring = this as Ring;
            if (ring is null) return false;
            if(ring.Price > 500)
            {
                return true;
            }
            return false;
        }
    }
}