namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Bellow { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Bellow = next;
            }

            public Node(T element)
            {
                this.Element = element;
            }
        }

        private Node top;

        public Stack()
        {
            this.top = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (this.Count == 0)
            {
                this.top = new Node(item);
                Count++;
            }
            else
            {
                Node newTop = new Node(item);
                newTop.Bellow = this.top;
                this.top = newTop;
                Count++;
            }
        }

        public T Pop()
        {
            if (this.Count > 0)
            {

                Node current = this.top;
                this.top = current.Bellow;
                Count--;
                return current.Element;
            }
            else throw new InvalidOperationException("Stack is empty!");
            
        }

        public T Peek()
        {
            if (this.Count > 0)
            {
                return this.top.Element;
            }
            else throw new InvalidOperationException("Stack is empty!");
        }

        public bool Contains(T item)
        {
            while (this.Count > 0) 
            {
                if (this.Pop().Equals(item)) return true;
                        
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = this.top;
            while(current != null) 
            {
                yield return current.Element;
                current = current.Bellow;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
