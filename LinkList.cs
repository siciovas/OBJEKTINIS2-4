using System;
using System.Collections.Generic;
using System.Collections;

namespace LD4.Polimorfizmas
{
    public class LinkList<T> : IEnumerable<T> where T: IComparable<T>, IEquatable<T>
    {
        private sealed class Node
        {
            public T Data { get; set; }
            public Node Link { get; set; }
            public Node(T value, Node address)
            {
                Data = value;
                Link = address;
            }
        }

        private Node Head;
        private Node Current;

        public LinkList()
        {
            this.Head = null;
            this.Current = null;
        }

        public void Start()
        {
            Current = Head;
        }

        public bool Is()
        {
            return Current != null;
        }

        public void Next()
        {
            Current = Current.Link;
        }

        public bool Exist()
        {
            return Head != null;
        }

        public T Get()
        {
            return Current.Data;
        }

        public void Add(T data)
        {
            Head = new Node(data, Head);
        }

        public void Sort()
        {
            if(Head != null)
            {
                for(Node d1 = Head; d1.Link != null; d1 = d1.Link)
                {
                    Node max = d1;
                    for(Node d2 = d1; d2 != null; d2 = d2.Link)
                    {
                        if(d2.Data.CompareTo(max.Data) > 0)
                        {
                            max = d2;
                        }
                    }
                    var mod = d1.Data;
                    d1.Data = max.Data;
                    max.Data = mod;
                }
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (Node dd = Head; dd != null; dd = dd.Link)
            {
                yield return dd.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}