namespace SinglyLinkedList
{
    /// <summary>
    /// This class represents a node in the Singly Linked List
    /// </summary>
    /// <typeparam name="T">A generic type specifying the type of values stored by the Linked List</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Constructor which sets the value of the node to the value passed as parameter
        /// </summary>
        /// <param name="value"></param>
        public Node(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Value of the node
        /// </summary>
        public T Value
        {
            get;
            set;
        }

        /// <summary>
        /// The pointer in the node which points to the next node
        /// </summary>
        public Node<T> Next
        {
            get;
            set;
        }
    }
}
