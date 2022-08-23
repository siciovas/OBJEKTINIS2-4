using LD4.Polimorfizmas;

namespace xUnitTests
{
    public class ChainTest : LinkListTests<Juvelry>
    {
        public override Juvelry FirstValue()
        {
            return new Chain('C', "Made", "Name", "Metal", 20, 355, 500, 15);
        }

        public override LinkList<Juvelry> ListSample()
        {
            LinkList<Juvelry> myList = new LinkList<Juvelry>();
            myList.Add(new Chain('R', "Poland", "Beauty", "Gold", 15, 353, 1000, 15));
            myList.Add(new Chain('R', "Lithuania", "Rock", "Bronze", 20, 870, 10000, 13));
            myList.Add(new Chain('R', "Sweden", "Blueberry", "Silver", 17, 555, 500, 10));
            return myList;
        }

        public override LinkList<Juvelry> NullList()
        {
            LinkList<Juvelry> list = new LinkList<Juvelry>();
            return list;
        }
    }
}
