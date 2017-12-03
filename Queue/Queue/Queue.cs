using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    /// <summary>
    /// Implementation of a queue data structure using linked list
    /// </summary>
    public class Queue<T> : IEnumerable<T>
    {
        LinkedList<T> _items = new LinkedList<T>();

        /// <summary>
        /// Adds an item to the back of the queue
        /// </summary>
        /// <param name="item">Item to be added</param>
        public void Enqueue(T item)
        {
            _items.AddLast(item);
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
