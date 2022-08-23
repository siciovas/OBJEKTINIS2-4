using LD4.Polimorfizmas;

namespace xUnitTests
{
    public class EarringTest : LinkListTests<Juvelry>
    {
        public override Juvelry FirstValue()
        {
            return new Earring('E', "Made", "Name", "Metal", 20, 355, 500, "Magnet");
        }

        public override LinkList<Juvelry> ListSample()
        {
            LinkList<Juvelry> myList = new LinkList<Juvelry>();
            myList.Add(new Earring('R', "Poland", "Beauty", "Gold", 15, 353, 1000, "Metal"));
            myList.Add(new Earring('R', "Lithuania", "Rock", "Bronze", 20, 870, 10000, "Pierced"));
            myList.Add(new Earring('R', "Sweden", "Blueberry", "Silver", 17, 555, 500, "Magnet"));
            return myList;
        }

        public override LinkList<Juvelry> NullList()
        {
            LinkList<Juvelry> list = new LinkList<Juvelry>();
            return list;
        }
    }
}
