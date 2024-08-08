using DSA_C_SHARP.DataStructures.LinkedList.SingleLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.LinkedList.DoubleLinkedList
{
    public class DoubleLinkedListNode<T>
    {
        public DoubleLinkedListNode(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }

        public T Data { get; }

        public DoubleLinkedListNode<T>? Next { get; set; }
        public DoubleLinkedListNode<T>? Prev { get; set; }
    }
}
