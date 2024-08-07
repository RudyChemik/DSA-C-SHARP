using System;

namespace DSA_C_SHARP.DataStructures.Queue
{
    /// <summary>
    /// FIFO (first in first out) QUEUE implementation on array.
    /// </summary>
    public class ArrayQueue<T>
    {
        private T[] queue;
        private int head;
        private int tail;
        private int capacity;
        private int count;

        /// <summary>
        /// Constructor, initializing queue
        /// </summary>
        /// <param name="capacity">since its an array implementation, the capacity will be maximum size of the queue</param>
        public ArrayQueue(int capacity)
        {
            this.capacity = capacity;
            queue = new T[capacity];
            head = 0;
            tail = 0;
            count = 0;
        }

        /// <summary>
        /// Enqueue items
        /// </summary>
        /// <param name="item">item pushed into the queue</param>
        public void Enqueue(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Overflow");

            queue[tail] = item;
            tail = (tail + 1) % capacity;
            count++;
        }

        /// <summary>
        /// Dequeue items (First in first out).
        /// </summary>
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("EXCEEDED!");

            T item = queue[head];
            queue[head] = default(T);
            head = (head + 1) % capacity;
            count--;

            return item;
        }

        public int Count() => count;
        public bool IsEmpty() => count == 0;
        public bool IsFull() => count == capacity;

    }
}
