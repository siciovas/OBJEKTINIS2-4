using System;

namespace LD4.Polimorfizmas
{
    public class Shop : IEquatable<Shop>, IComparable<Shop>
    {
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public decimal ShopPhone { get; set; }
        public LinkList<Juvelry> AllJuvelries { get; set; }

        public Shop(string shopName, string shopAddress, decimal shopPhone)
        {
            this.ShopName = shopName;
            this.ShopAddress = shopAddress;
            this.ShopPhone = shopPhone;
            AllJuvelries = new LinkList<Juvelry>();
        }

        public void AddJuvelry(Juvelry juvelry)
        {
            AllJuvelries.Add(juvelry);
        }

        public bool Equals(Shop other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Shop other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return String.Format("{0,-20} | {1,-20} | {2, 15} |", ShopName, ShopAddress, ShopPhone);
        }
    }
}