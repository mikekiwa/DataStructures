// Ashwin V Prabhu
using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    /// <summary>
    /// A linked list implementation of stack data structure
    /// </summary>
    /// <typeparam name="T">Type of item contained in the stack</typeparam>
    public class Stack<T> : IEnumerable<T>
    {
        LinkedList<T> _list = new LinkedList<T>();

        /// <summary>
        /// Pushed an item on to the stack
        /// </summary>
        /// <param name="item">item to be pushed</param>
        public void Push(T item)
        {
            _list.AddFirst(item);
        }

        /// <summary>
        /// Removes the top of the stack
        /// </summary>
        /// <returns>Returns the value which was removed</returns>
        public T Pop()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T value = _list.First.Value;
            _list.RemoveFirst();
            return value;
        }

        /// <summary>
        /// Returns the top of the stack without removing it
        /// </summary>
        /// <returns>Value at the top of the stack</returns>
        public T Peek()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _list.First.Value;
        }

        /// <summary>
        /// Holds the number of elements in the stack
        /// </summary>
        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        /// <summary>
        /// Removes all the elements from the stack
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        /// Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
