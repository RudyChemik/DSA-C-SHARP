using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.LinkedList.SingleLinkedList
{
    public class SingleLinkedListNode<T>
    {
        public SingleLinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }

        public T Data { get; }

        public SingleLinkedListNode<T>? Next { get; set; }

    }
}
