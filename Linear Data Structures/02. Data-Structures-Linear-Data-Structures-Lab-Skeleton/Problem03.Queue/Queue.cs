namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
            {
                this.Element = element;
            }
        }

        private Node head;

        public Queue()
        {
            this.head = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (Count == 0)
            {
                this.head  = new Node(item);
                this.Count++;
            }
            else 
            {
                Node current = this.head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                
                current.Next = new Node(item);
                this.Count++;
            }
        }

        public T Dequeue()
        {
            if(this.Count > 0) 
            {
                Node current = this.head;
                Node next = current.Next;
                this.head = next;
                Count--;
                return current.Element;
            }
            else throw new InvalidOperationException("Queue is empty!");
        }

        public T Peek()
        {
            if (this.Count > 0)
            {
                return this.head.Element;
            }
            else throw new InvalidOperationException("Queue is empty!");
        }

        public bool Contains(T item)
        {
            Node current = this.head;
            while (current != null)
            {
                if (current.Element.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = this.head;
            while (current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}