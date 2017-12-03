using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        LinkedList<T> _items = new LinkedList<T>();

        /// <summary>
        /// Adds an item to the queue in an order of priority
        /// </summary>
        /// <param name="item">Item to be added</param>
        public void Enqueue(T item)
        {
            // Add the item if the list is empty
            if (_items.Count == 0)
            {
                _items.AddLast(item);
            }
            else
            {
                var current = _items.First;

                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    _items.AddLast(item);
                }
                else
                {
                    _items.AddBefore(current, item);
                }
            }
        }

        /// <summary>
        /// Removes the element at the front of the queue
        /// </summary>
        /// <returns>The value of the element which was removed</returns>
        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T value = _items.First.Value;
            _items.RemoveFirst();

            return value;
        }

        /// <summary>
        /// Returns the item from the front of the queue without removing it
        /// </summary>
        /// <returns>The value of the element at the front of the queue</returns>
        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _items.First.Value;
        }

        /// <summary>
        /// The number of items in the queue
        /// </summary>
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        /// <summary>
        /// Removes all items from the queue
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }

        /// <summary>
        /// Returns an enumerator that enumerates the queue
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that enumerates the queue
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
