using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.LinkedList.SingleLinkedList
{
    /// <summary>
    /// Linked list implementation where each element is linked to the next one
    /// </summary>
    public class SingleLinkedList<T>
    {
        //points to the first elem
        private SingleLinkedListNode<T>? Head { get; set; }

        /// <summary>
        /// Deleting element from the back of the structure
        /// </summary>
        public void DeleteLast()
        {
            //if head is null, so is the list - cant delete anything returning ex
            if (Head == null)
                throw new InvalidOperationException("EMPTY");

            //case when the last element is the only elem in the list
            if (Head.Next == null)
            {
                Head = null;
                return;
            }

            //normal case, list is not empty and has more then 2 elems
            //starting from the head, we iterate through elems to the point where the pointer to the next one is empty - which means we are at the very end of the linkedList
            SingleLinkedListNode<T> current = Head;
            while (current.Next?.Next != null)
            {
                current = current.Next;
            }

            current.Next = null;
        }

        /// <summary>
        /// Deleting first elem from the linked list
        /// </summary>
        public void DeleteFirst()
        {
            //if empty, throw
            if (Head == null)
                throw new InvalidOperationException("EMPTY");

            Head = Head.Next;
        }

        /// <summary>
        /// Adding to the back of the list
        /// </summary>
        /// <param name="data">content of the new node</param>>
        public void AddLast(T data)
        {
            //init
            SingleLinkedListNode<T> newNode = new SingleLinkedListNode<T>(data);

            //if list is empty, adding elem as list head
            if (Head == null)
            {
                Head = newNode;
                return;
            }

            //iteration through the list and adding at the back
            SingleLinkedListNode<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        /// <summary>
        /// Adding at the front
        /// </summary>
        /// <param name="data">content of the new node</param>>
        public void AddFirst(T data)
        {
            SingleLinkedListNode<T> newNode = new SingleLinkedListNode<T>(data)
            {
                Next = Head
            };
            Head = newNode;
        }

        /// <summary>
        /// Getting the data from the list
        /// </summary>
        /// <param name="index">position of the data</param>>
        public T Get(int index)
        {
            //throw when -1 or so
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Out of bonnds");

            SingleLinkedListNode<T>? current = Head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                    return current.Data;

                current = current.Next;
                currentIndex++;
            }

            throw new ArgumentOutOfRangeException(nameof(index), "Out of bonds");
        }

        /// <summary>
        /// Getting the length of the list
        /// </summary>
        public int Length()
        {
            int length = 0;
            SingleLinkedListNode<T>? current = Head;

            while (current != null)
            {
                length++;
                current = current.Next;
            }

            return length;
        }
    }


}

