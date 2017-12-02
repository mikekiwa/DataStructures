using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    public class SinglyLinkedList<T> : ICollection<T>
    {
        #region Singly Linked List properties
        /// <summary>
        /// Head node points to the beginning of the linked list
        /// </summary>
        public Node<T> Head
        {
            get;
            private set;
        }

        /// <summary>
        /// Tail node points to the end of the linked list
        /// </summary>
        public Node<T> Tail
        {
            get;
            private set;
        }
        #endregion

        #region Add to Singly Linked List
        /// <summary>
        /// Add a node to the beginning of the list
        /// </summary>
        /// <param name="node">Node to be added is passed as parameter</param>
        public void AddFirst(Node<T> node)
        {
            // Backing up the current head node temporarily
            Node<T> temp = Head;

            // Head is set to the node, to be added at the beginning
            Head = node;

            // The new node added is made to point to the rest of the linked list
            Head.Next = temp;
            
            Count++;

            // If the linked list was empty, the head and tail should be the same,
            // pointing to the first element
            if (Count == 1)
            {
                Tail = Head;
            }
        }

        /// <summary>
        /// Add a node to the beginning of the list
        /// </summary>
        /// <param name="value">Value of node to be added is passed as parameter</param>
        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
        }

        /// <summary>
        /// Add the value to the end of the list
        /// </summary>
        /// <param name="value">The value to add</param>
        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }

        /// <summary>
        /// Add the node to the end of the list
        /// </summary>
        /// <param name="value">The node to add</param>
        public void AddLast(Node<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;

            Count++;
        }
        #endregion

        #region Remove from Singly Linked List
        /// <summary>
        /// Removing the first element from the linked list
        /// </summary>
        public void RemoveFirst()
        {
            // Check if the list is not empty
            if (Count != 0)
            {
                // Move head to point to the next node
                Head = Head.Next;

                // Decrease the count of the head node
                Count--;

                // If the linked list is empty, the Tail should point to null
                if (Count == 0)
                {
                    Tail = null;
                }
            }
        }

        /// <summary>
        /// Removes the last node from the linked list
        /// </summary>
        public void RemoveLast()
        {
            // Check if the linked list is not empty
            if (Count != 0)
            {
                // If there is only one element in the linked list
                if (Count == 1)
                {
                    Head = Tail = null;
                }
                else
                {
                    Node<T> current = Head;
                    
                    // Iterate to the second last element in the linked list
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }

                    // Remove the link to the last element
                    current.Next = null;

                    // Reassign second last element as the last element
                    Tail = current;
                }
                Count--;
            }
        }
        #endregion

        #region Implementing ICollection interface
        /// <summary>
        /// Holds the value of number of nodes in the linked list
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        /// Holds true if the list is read only
        /// This list is not read only and hence it always returns false
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }

        }

        /// <summary>
        /// Add an item to the front of the linked list
        /// </summary>
        /// <param name="item">Item to be added</param>
        public void Add(T item)
        {
            AddFirst(item);
        }

        /// <summary>
        /// Clears the linked list
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Checks if a particular item is present in the linked list
        /// </summary>
        /// <param name="item">Item to check for</param>
        /// <returns>true if the item is found, and false if its not found</returns>
        public bool Contains(T item)
        {
            Node<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Copies the node values in linked list to the specified array
        /// </summary>
        /// <param name="array">The array to copy the linked list value to</param>
        /// <param name="arrayIndex">The index in the array to start copying at</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> current = Head;

            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Enumerates over the linked list from head to tail
        /// </summary>
        /// <returns>Every value in the list</returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Removes the first occurence of the item from the list
        /// searching from head to tail
        /// </summary>
        /// <param name="item">Item to be deleted</param>
        /// <returns>true if the item is removed, and false otherwise</returns>
        public bool Remove(T item)
        {
            Node<T> previous = null;
            Node<T> current = Head;

            // 1: Empty list - do nothing
            // 2: Single node: (previous is null)
            // 3: Many nodes
            //    a: node to remove is the first node
            //    b: node to remove is the middle or last

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    // If the node is in the middle or at the end
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        // If the node is at the end
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        // Single node or the first node to remove
                        RemoveFirst();
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Enumerates over linked list from head to tail
        /// </summary>
        /// <returns>Every values in the list</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
        #endregion
    }
}
