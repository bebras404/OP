using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3
{
    public sealed class ListClass<T> : IEnumerable<T> where T : IComparable<T>, IEquatable<T>
    {
        public class Node
        {
            public T Data { get; set; }
            public Node Link { get; set; }

            public Node(T data, Node next)
            {
                this.Data = data;
                this.Link = next;
            }
        }

        Node Head;
        Node Current;

        public ListClass()
        {
            Head = null;
            Current = null;
        }

        public void Add(T value)
        {
            Node newNode = new Node(value, null);

            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Node current = Head;
            while (current.Link != null)
            {
                current = current.Link;
            }

            current.Link = newNode;
        }

        public void Start()
        {
            Current = Head;
        }

        public void Next()
        {
            Current = Current.Link;
        }

        public bool Exists()
        {
            return Current != null;
        }

        public T Get()
        {
            return Current.Data;
        }

        public bool Contains(T node)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Data.Equals(node))
                {
                    return true;
                }
                current = current.Link;
            }
            return false;
        }

        public void Sort() 
        {
            for (Node outer = Head; outer != null; outer = outer.Link)
            {
                Node min = outer;
                for (Node inner = outer.Link; inner != null; inner = inner.Link)
                {
                    if (inner.Data.CompareTo(min.Data) < 0)
                    {
                        min = inner;
                    }
                }

                if (min != outer)
                {
                    T temp = outer.Data;
                    outer.Data = min.Data;
                    min.Data = temp;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Link;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
