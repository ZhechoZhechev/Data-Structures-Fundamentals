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
            Node ElToAdd = new Node(item);
            if (Count == 0)
            {
                this.Head = this.Tail = ElToAdd;
            }
            else
            {
                Node previousHead = this.Head;
                this.Head = ElToAdd;
                previousHead.Previous = this.Head;
                this.Head.Next = previousHead;
            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node ElToAdd = new Node(item);
            if (Count == 0)
            {
                this.Head = this.Tail = ElToAdd;
            }
            else
            {
                Node previousTail = this.Tail;
                this.Tail = ElToAdd;
                previousTail.Next = this.Tail;
                this.Tail.Previous = previousTail;
            }
            this.Count++;
        }

        public T GetFirst()
        {
            this.IfCollectionIsEmpty();
            return this.Head.Value;
        }
        public T GetLast()
        {
            this.IfCollectionIsEmpty();
            return this.Tail.Value;
        }

        public T RemoveFirst()
        {
            this.IfCollectionIsEmpty();

            if (Count == 1) 
            {
                var current = this.Head;
                this.Head = this.Tail = null;
                this.Count--;
                return current.Value;
            }
            else
            {
                var current = this.Head;
                this.Head = current.Next;
                this.Head.Previous = null;
                this.Count--;
                return current.Value;
            }
        }

        public T RemoveLast()
        {
            this.IfCollectionIsEmpty();

            if (Count == 1)
            {
                var current = this.Tail;
                this.Head = this.Tail = null;
                this.Count--;
                return current.Value;
            }
            else
            {
                var current = this.Tail;
                this.Tail = current.Previous;
                this.Tail.Next = null;
                this.Count--;
                return current.Value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void IfCollectionIsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
        }
    }
}
