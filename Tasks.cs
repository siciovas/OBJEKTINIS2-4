using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD4.Polimorfizmas
{
    public static class Tasks
    {
        /// <summary>
        /// Method finds most expensive Ring, Earring and Chain, and shows in which market it is.
        /// </summary>
        /// <param name="type">type of juvelry(R, E, C)</param>
        /// <param name="shops">shops linklist</param>
        /// <returns>shop object</returns>
        public static Shop FindMostExpensiveREC(char type, LinkList<Shop> shops)
        {
            Shop uniqueShop = null;
            decimal maximum = decimal.MinValue;

            foreach(Shop shop in shops)
            {
                foreach(Juvelry juvelry in shop.AllJuvelries)
                {
                    if(juvelry.Type.Equals(type) && juvelry.Price > maximum)
                    {
                        maximum = juvelry.Price;
                        uniqueShop = shop;
                    }
                }
            }
            return uniqueShop;
        }
        /// <summary>
        /// Method finds juvelry that you can buy only in one shop, and shows shop information and information about that juvelry
        /// </summary>
        /// <param name="shops">shops linklist</param>
        /// <returns>returns list of shops and unique juvelries</returns>
        public static LinkList<Shop> FindUniques(LinkList<Shop> shops)
        {
            LinkList<Shop> shopList = new LinkList<Shop>();

            foreach (Shop shop in shops)
            {
                Shop uniqueShop = new Shop(shop.ShopName, shop.ShopAddress, shop.ShopPhone);
                foreach (Juvelry juvelry in shop.AllJuvelries)
                {
                    bool flag = true;
                    foreach (Shop shop1 in shops)
                    {
                        if (shop.ShopName.Equals(shop1.ShopName)) { }

                        else
                        {
                            foreach (Juvelry juvelry1 in shop1.AllJuvelries)
                            {
                                if (juvelry.Equals(juvelry1))
                                {
                                    flag = false;
                                }
                            }
                            if (!flag)
                            {
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        uniqueShop.AddJuvelry(juvelry);
                    }
                }
                shopList.Add(uniqueShop);
            }
            return shopList;
        }
        /// <summary>
        /// Method finds juvelries that costs lower than 300
        /// </summary>
        /// <param name="shops">shops linklist</param>
        /// <returns>returns list of juvelries</returns>
        public static LinkList<Juvelry> CheaperThan300(LinkList<Shop> shops)
        {
            LinkList<Juvelry> listJuvelries = new LinkList<Juvelry>();

            foreach(Shop shop in shops)
            {
                foreach(Juvelry juvelry in shop.AllJuvelries)
                {
                    if(juvelry.Price <= 300)
                    {
                        listJuvelries.Add(juvelry);
                    }
                }
            }
            return listJuvelries;
        }
        /// <summary>
        /// Method finds Rings who cost more than 500, Earrings costs more than 300, Chains costs more than 150
        /// </summary>
        /// <param name="shops">shops linklist</param>
        /// <returns>returns list oj juvelries</returns>
        public static LinkList<Juvelry> FindExpensiveWithDifferentPrice(LinkList<Shop> shops)
        {
            LinkList<Juvelry> juvelries = new LinkList<Juvelry>();

            foreach (Shop shop in shops)
            {
                foreach (Juvelry juvelry in shop.AllJuvelries)
                {
                   if(juvelry.IsExpensive())
                    {
                        juvelries.Add(juvelry);
                    }
                }
            }
            return juvelries;
        }
        
    }
}