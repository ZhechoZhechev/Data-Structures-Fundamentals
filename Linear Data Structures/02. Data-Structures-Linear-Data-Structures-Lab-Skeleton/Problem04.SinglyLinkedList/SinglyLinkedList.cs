namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        class Node
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
        public SinglyLinkedList()
        {
            this.head = null;
            this.Count = 0;
        }
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            if (this.Count == 0)
            {
                this.head = new Node(item);
            }
            else
            {
                var current = this.head;
                this.head = new Node(item);
                this.head.Next = current;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node toInsert = new Node(item);
            Node current = this.head;
            if (current == null)
            {
                this.head = toInsert;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = toInsert;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            if (this.Count != 0)
            {
                return this.head.Element;
            }
            else
            {
                throw new InvalidOperationException("List is empty!");
            }
        }

        public T GetLast()
        {
            if (this.Count != 0)
            {
                Node current = this.head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                return current.Element;
            }
            else
            {
                throw new InvalidOperationException("List is empty!");
            }
        }

        public T RemoveFirst()
        {
            if (this.Count != 0)
            {
                var current = this.head;
                this.head = current.Next;
                this.Count--;
                return current.Element;
            }
            else
            {
                throw new InvalidOperationException("List is empty!");
            }

        }

        public T RemoveLast()
        {
            var current  = this.head;
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
            else if (this.Count == 1)
            {
                this.head = null;
                this.Count--;
                return current.Element;
            }
            else
            {
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                var last = current.Next;
                current.Next = null;
                this.Count--;
                return last.Element;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
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