using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.LinkedList.DoubleLinkedList
{
    /// <summary>
    /// Doubly linked list implementation where each element have pointers to the neighbours (left, and right)
    /// </summary>
    public class DoubleLinkedList <T>
    {
        //first elem
        private DoubleLinkedListNode<T>? Head { get; set; }
        //last elem
        private DoubleLinkedListNode<T>? Tail { get; set; }

        /// <summary>
        /// Adding to the front of the list
        /// </summary>
        /// <param name="data">content of the new node</param>>
        public void AddFirst(T data)
        {
            DoubleLinkedListNode<T> newNode = new DoubleLinkedListNode<T>(data);
            //if head is empty, so is the list new node becomes the head
            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = newNode;
            }
        }

        /// <summary>
        /// Adding at the back of the list
        /// </summary>
        /// <param name="data">content of the new node</param>>
        public void AddLast(T data)
        {
            DoubleLinkedListNode<T> newNode = new DoubleLinkedListNode<T>(data);
            if (Tail == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
        }

        /// <summary>
        /// Deleting first elem
        /// </summary>
        public void DeleteFirst()
        {
            //empty list
            if (Head == null)
                throw new InvalidOperationException("EMPTY");

            //one elem case
            if (Head == Tail)
            {
                Head = Tail = null;
            }
            else //normal
            {
                Head = Head.Next;
                if (Head != null)
                {
                    Head.Prev = null;
                }
            }
        }

        /// <summary>
        /// Deleting last elem
        /// </summary>
        public void DeleteLast()
        {
            //empty list
            if (Tail == null)
                throw new InvalidOperationException("EMPTY");

            //single elem list case
            if (Head == Tail)
            {
                Head = Tail = null;
            }
            else //normal
            {
                Tail = Tail.Prev;
                if (Tail != null)
                {
                    Tail.Next = null;
                }
            }
        }

        /// <summary>
        /// Getting the data from the list
        /// </summary>
        /// <param name="index">position of the data</param>>
        public T Get(int index)
        {
            //throw when index is negative
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Out of bonds");

            DoubleLinkedListNode<T>? current = Head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                    return current.Data;

                current = current.Next;
                currentIndex++;
            }

            throw new ArgumentOutOfRangeException(nameof(index), "out of bonds");
        }

        /// <summary>
        /// Getting the length of the list
        /// </summary>
        public int Length()
        {
            int length = 0;
            DoubleLinkedListNode<T>? current = Head;

            while (current != null)
            {
                length++;
                current = current.Next;
            }

            return length;
        }
    }
}

