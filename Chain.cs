using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD4.Polimorfizmas
{
    public class Chain : Juvelry
    {
        public int Length { get; private set; }
        public Chain(char type, string made, string name, string metal, int weight, int purity, decimal price, int length) 
            : base(type,made,name,metal,weight,purity,price)
        {
            this.Length = length;
        }

        public override int CompareTo(Juvelry other)
        {
            Chain chain = other as Chain;
            if(chain is null) return 0;
            return this.Length.CompareTo(chain.Length);
        }

        public override bool Equals(Juvelry other)
        {
            Chain chain = other as Chain;
            if (chain is null) return false;
            return this.Type.Equals(chain.Type) && this.Made.Equals(chain.Made) && this.Name.Equals(chain.Name)
                && this.Metal.Equals(chain.Metal) && this.Weight.Equals(chain.Weight) && this.Purity.Equals(chain.Purity)
                && this.Price.Equals(chain.Price) && this.Length.Equals(chain.Length);
        }

        public override string ToString()
        {
            return string.Format("{0} ; {1} ; {2} ; {3} ; {4} ; {5} ; {6} ; {7}", Type, Made, Name, Metal, Weight,
                Purity, Price, Length);
        }

        public override bool IsExpensive()
        {
            Chain chain = this as Chain;
            if (chain is null) return false;
            if(chain.Price > 150)
            {
                return true;
            }
            return false;
        }
    }
}