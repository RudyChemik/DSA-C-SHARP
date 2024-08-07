using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.Stack
{
    /// <summary>
    /// STACK implementation on arrays.
    /// FILO (first in last out).
    /// </summary>
    public class ArrayStack<T>
    {
        public T[] stack;
        private int capacity;
        private int top;

        /// <summary>
        /// Constructor - initialization of the stack.
        /// </summary>
        public ArrayStack(int capacity) 
        {
            this.capacity = capacity;
            stack = new T [capacity];
            top = -1;
        }

        /// <summary>
        /// Pushing at the top
        /// </summary>

        public void Push(T item) 
        {
            if (IsFull())
                throw new InvalidOperationException("OVERFLOW!");

            top++;
            stack[top] = item;

        }

        /// <summary>
        /// Popping lastly pushed element
        /// </summary>
        public T Pop() 
        {
            if (IsEmpty())
                throw new InvalidOperationException("EMPTY, EXCEEDED!");

            T ret = stack[top];
            top--;
            return ret;

        }

        public bool IsFull() => capacity - 1 == top;
        public bool IsEmpty() => top == -1;
        public int Count() => top + 1;
    }
}
