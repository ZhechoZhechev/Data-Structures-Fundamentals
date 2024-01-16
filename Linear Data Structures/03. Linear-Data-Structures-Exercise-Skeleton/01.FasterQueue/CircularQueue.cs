namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;
        private int startIndex;
        private int endIndex;
        private const int INITIAL_SIZE = 4;

        public CircularQueue(int capacity = INITIAL_SIZE)
        {
            this.elements = new T[capacity];
        }
        public int Count { get; private set; }

        public T Dequeue()
        {
            CheckIfEmpty();
            var result = this.elements[this.startIndex];
            this.startIndex = (this.startIndex +1) % this.elements.Length;
            this.Count--;
            return result;
        }

        public void Enqueue(T item)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        public T Peek()
        {
            this.CheckIfEmpty();
            return this.elements[this.startIndex];
        }

        public T[] ToArray()
        {
            return this.CopyAllElementsTo(new T[this.Count]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                var currIndex = (this.startIndex + i) % this.elements.Length;
                yield return this.elements[currIndex];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Grow()
        {
            this.elements = CopyAllElementsTo(new T[this.elements.Length * 2]);
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private T[] CopyAllElementsTo(T[] resultArray)
        {
            var sourceIndex = this.startIndex;
            for (int i = 0; i < this.Count; i++)
            {
                resultArray[i] = this.elements[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.elements.Length;
            }

            return resultArray;
        }

        private void CheckIfEmpty()
        {
            if (this.Count == 0) throw new InvalidOperationException("Queue empty!");
        }

    }
}