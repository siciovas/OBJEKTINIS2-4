using LD4.Polimorfizmas;

namespace xUnitTests
{
    public class RingTest : LinkListTests<Juvelry>
    {
        public override Juvelry FirstValue()
        {
            return new Ring('R', "Made", "Name", "Metal", 20, 355, 500, 20);
        }

        public override LinkList<Juvelry> ListSample()
        {
            LinkList<Juvelry> myList = new LinkList<Juvelry>();      
            myList.Add(new Ring('R', "Poland", "Beauty", "Gold", 15, 353, 1000, 20));
            myList.Add(new Ring('R', "Lithuania", "Rock", "Bronze", 20, 870, 10000, 15));
            myList.Add(new Ring('R', "Sweden", "Blueberry", "Silver", 17, 555, 500, 19));
            return myList;
        }

        public override LinkList<Juvelry> NullList()
        {
            LinkList<Juvelry> list = new LinkList<Juvelry>();
            return list;
        }
    }
}
