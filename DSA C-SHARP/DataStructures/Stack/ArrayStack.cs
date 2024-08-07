using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.Stack
{
    public class ArrayStack<T>
    {
        public T[] stack;
        private int capacity;
        private int top;

        public ArrayStack(int capacity) 
        {
            this.capacity = capacity;
            stack = new T [capacity];
            top = -1;
        }

        public void Push(T item) 
        {
            if (IsFull())
                throw new InvalidOperationException("OVERFLOW!");

            top++;
            stack[top] = item;

        }

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
