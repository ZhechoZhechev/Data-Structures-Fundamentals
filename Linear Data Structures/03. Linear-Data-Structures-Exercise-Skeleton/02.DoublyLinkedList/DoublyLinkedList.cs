namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Previous { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {
                this.Value = value;
                this.Previous = null;
                this.Next = null;
            }
        }
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; private set; }

        public DoublyLinkedList()
        {
            this.Tail = null;
            this.Head = null;
            this.Count = 0;
        }

        public void AddFirst(T item)
        {
            throw new NotImplementedException();
        }

        public void AddLast(T item)
        {
            throw new NotImplementedException();
        }

        public T GetFirst()
        {
            throw new NotImplementedException();
        }

        public T GetLast()
        {
            throw new NotImplementedException();
        }

        public T RemoveFirst()
        {
            throw new NotImplementedException();
        }

        public T RemoveLast()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}