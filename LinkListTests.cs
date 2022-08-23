using System;
using Xunit;
using LD4.Polimorfizmas;

namespace xUnitTests
{
    public abstract class LinkListTests<T> where T: IComparable<T>, IEquatable<T>
    {
        public abstract T FirstValue();
        public abstract LinkList<T> ListSample();
        public abstract LinkList<T> NullList();

        [Fact]
        public void LinkList_CreateLinkList_HeadnCurrentEqualsNull()
        {
            bool expected = false;
            LinkList<T> list = NullList();
            list.Start();
            bool actual = list.Is();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_DataNode_AnswerHead()
        {
            T expected = FirstValue();
            LinkList<T> linkedList = ListSample();

            linkedList.Add(expected);
            linkedList.Start();

            T actual = linkedList.Get();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Is_CurrentNode_False()
        {
            bool expected = false;

            LinkList<T> myList = NullList();
            bool actual = myList.Is();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Exist_HeadNode_False()
        {
            bool expected = false;

            LinkList<T> myList = NullList();
            bool actual = myList.Exist();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_CorrectIndex_True()
        {
            T expected = FirstValue();
            LinkList<T> myList = ListSample();
            T value = FirstValue();

            myList.Add(value);
            myList.Start();

            T actual = myList.Get();

            Assert.Equal(expected, actual);
        }
    }
}
