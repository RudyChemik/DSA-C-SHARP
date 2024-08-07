using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.Stack
{
    /// <summary>
    /// STACK implementation on linkedList from c#.
    /// FILO (first in last out).
    /// </summary>
    public class ListStack<T>
    {
        public LinkedList<T> stack;

        /// <summary>
        /// Constructor - initialization of the stack.
        /// </summary>
        public ListStack() 
        {
            stack = new LinkedList<T>();
        }

        /// <summary>
        /// Popping lastly pushed value.
        /// </summary>
        public T Pop() 
        {
            if (IsEmpty())
                throw new InvalidOperationException("EMPTY!");

            var item = stack.First.Value;
            stack.RemoveFirst();
            return item;
        }

        /// <summary>
        /// Pushing at the top
        /// </summary>
        public void Push(T item) 
        {
            stack.AddFirst(item);
        }

        public int Count() => stack.Count();
        public bool IsEmpty() => !stack.Any();
        public void Clear() => stack.Clear();
    }
}
