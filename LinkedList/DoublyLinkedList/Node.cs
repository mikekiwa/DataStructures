namespace DoublyLinkedList
{
    /// <summary>
    /// Node in the doubly linked list
    /// </summary>
    /// <typeparam name="T">specifies the type of data to be stored in the linked list</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Constructor to create a new node
        /// </summary>
        /// <param name="value">Value of the node</param>
        public Node(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Node value
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Points to the next node in the linked list
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// Points to the previous node in the linked list
        /// </summary>
        public Node<T> Previous { get; set; }
    }
}
