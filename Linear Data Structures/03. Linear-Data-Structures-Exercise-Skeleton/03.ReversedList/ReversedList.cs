namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[this.Count - 1 - index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.GrowIfNeeded();
            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) == -1 ? false : true;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[(this.Count - 1) - i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            GrowIfNeeded();
            int indexToInsert = this.Count - index;
            for (int i = this.Count; i > indexToInsert; i--)
            {
                this.items[i] = this.items[i - 1];
            }
            this.items[indexToInsert] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index == -1 )
            {
                return false;
            }
            else
            {
                this.RemoveAt(index);
                return true;
            }
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            int indexToRemove = this.Count - 1 - index;
            for (int i = indexToRemove; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void GrowIfNeeded() 
        {
            if (this.items.Length == this.Count)
            {
                this.Grow();
            }
        }

        private void Grow()
        {
            T[] newArr = new T[this.items.Length * 2];
            Array.Copy(this.items, newArr, this.items.Length);
            this.items = newArr;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }
        }
    }
}