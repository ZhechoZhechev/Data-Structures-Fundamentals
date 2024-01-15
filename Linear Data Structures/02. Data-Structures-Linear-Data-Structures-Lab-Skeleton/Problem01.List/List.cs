namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));
            this.items = new T[capacity];
        }

        public T this[int index] 
        {
            get
            {
                if (this.IfIndexIsValid(index)) return items[index];
                else throw new IndexOutOfRangeException(nameof(index));
            }
            set
            {
                if(this.IfIndexIsValid(index)) this.items[index] = value;
                else throw new IndexOutOfRangeException(nameof(index));
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.ExtendIfNeccessary();
            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }


        public int IndexOf(T item)
        {
            if (Contains(item)) 
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this.items[i].Equals(item))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (IfIndexIsValid(index))
            {
                ExtendIfNeccessary();
                for (int i = this.items.Length - 1; i > index; i--)
                {
                    this.items[i] = this.items[i - 1];
                }
                this.items[index] = item;
                Count++;
            }
            else throw new IndexOutOfRangeException("Invalid index");
        }

        public bool Remove(T item)
        {
            if (this.Contains(item))
            {
                int index = this.IndexOf(item);
                this.RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (this.IfIndexIsValid(index))
            {
                this.items[index] = default(T);
                for (int i = index; i < this.Count -1; i++)
                {
                    this.items[i] = this.items[i + 1];
                }
                this.Count--;
            }
            else throw new IndexOutOfRangeException("Invalid index");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private bool IfIndexIsValid(int index) 
        {
            return index >= 0 && index < this.Count;
        }

        private void ExtendIfNeccessary()
        {
            if (this.Count == this.items.Length)
            {
                this.items = ExtendCollection();
            }
        }

        private T[] ExtendCollection()
        {
            var extended = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                extended[i] = this.items[i];
            }

            return extended;
        }
    }
}