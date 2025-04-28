using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3
{
    /// <summary>
    /// Class for linked list.
    /// </summary>
    /// <typeparam name="T">Generic object type.</typeparam>
    public sealed class ListClass<T> : IEnumerable<T> where T : IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Node class for linked list.
        /// </summary>
        private sealed class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Link { get; set; }

            /// <summary>
            /// Constructor for node.
            /// </summary>
            /// <param name="data">Data to add.</param>
            /// <param name="next">Pointer to next node.</param>

            public Node(T data, Node<T> next)
            {
                this.Data = data;
                this.Link = next;
            }
        }

        Node<T> Head;
        Node<T> Current;

        /// <summary>
        /// Constructor for linked list.
        /// </summary>
        public ListClass()
        {
            Head = null;
            Current = null;
        }
        /// <summary>
        /// Adds a new node to the end of the linked list.
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value, null);

            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Node<T> current = Head;
            while (current.Link != null)
            {
                current = current.Link;
            }

            current.Link = newNode;
        }
        /// <summary>
        /// Starts the linked list.
        /// </summary>
        public void Start()
        {
            Current = Head;
        }
        /// <summary>
        /// Moves to the next node in the linked list.
        /// </summary>
        public void Next()
        {
            Current = Current.Link;
        }
        /// <summary>
        /// Checks if the current node exists.
        /// </summary>
        /// <returns>True if exists, else false.</returns>
        public bool Exists()
        {
            return Current != null;
        }
        /// <summary>
        /// Gets the current node data.
        /// </summary>
        /// <returns>Data of a node.</returns>
        public T Get()
        {
            return Current.Data;
        }
        /// <summary>
        /// Adds a new node to the start of the linked list.
        /// </summary>
        /// <param name="node">Node to check.</param>
        /// <returns>True if contains, else false.</returns>
        public bool Contains(T node)
        {
            Node<T> current = Head;
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
        /// <summary>
        /// Sorts the linked list using selection sort.
        /// </summary>
        public void Sort() 
        {
            for (Node<T> outer = Head; outer != null; outer = outer.Link)
            {
                Node<T> min = outer;
                for (Node<T> inner = outer.Link; inner != null; inner = inner.Link)
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
        /// <summary>
        /// Gets the count of nodes in the linked list.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Link;
            }
        }
        /// <summary>
        /// Gets the count of nodes in the linked list.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
