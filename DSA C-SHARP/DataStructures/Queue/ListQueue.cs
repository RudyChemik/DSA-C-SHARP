using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.Queue
{
    /// <summary>
    /// FIFO (first in first out) QUEUE implementation on linked list provided in c#
    /// </summary>
    public class ListQueue<T>
    {
        private readonly LinkedList<T> queue;

        /// <summary>
        /// Constructor, initializing queue
        /// </summary>
        public ListQueue() 
        {
            queue = new LinkedList<T>();
        }

        /// <summary>
        /// Enqueue items
        /// </summary>
        public void Enque(T item) 
        {
            queue.AddLast(item);
        }

        /// <summary>
        /// Dequeue items FIFO.
        /// </summary>
        public T Dequeue() 
        {
            if (IsEmpty())
                throw new InvalidOperationException("EMPTY!");

            var item = queue.First;
            queue.RemoveFirst();
            return item.Value;
        }

        public bool IsEmpty() => !queue.Any();
        public int Count() => queue.Count();
    }
}
