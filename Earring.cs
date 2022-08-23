using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD4.Polimorfizmas
{
    public class Earring : Juvelry
    {
        public string ClaspType { get; private set; }

        public Earring(char type, string made, string name, string metal, int weight, int purity, decimal price, string claspType) 
            : base(type,made,name,metal,weight,purity,price)
        {
            this.ClaspType = claspType;
        }

        public override int CompareTo(Juvelry other)
        {
            Earring earring = other as Earring;
            if (earring is null) return 0;
            return earring.ClaspType.CompareTo(this.ClaspType);
        }

        public override bool Equals(Juvelry other)
        {
            Earring earring = other as Earring;
            if (earring is null) return false;
            return this.Type.Equals(earring.Type) && this.Made.Equals(earring.Made) && this.Name.Equals(earring.Name)
                && this.Metal.Equals(earring.Metal) && this.Weight.Equals(earring.Weight) && this.Purity.Equals(earring.Purity)
                && this.Price.Equals(earring.Price) && this.ClaspType.Equals(earring.ClaspType);
        }
        public override string ToString()
        {
            return string.Format("{0} ; {1} ; {2} ; {3} ; {4} ; {5} ; {6} ; {7}", Type, Made, Name, Metal, Weight,
                Purity, Price, ClaspType);
        }

        public override bool IsExpensive()
        {
            Earring earring = this as Earring;

            if (earring is null) return false;
            if(earring.Price > 300)
            {
                return true;
            }

            return false;
        }
    }
}