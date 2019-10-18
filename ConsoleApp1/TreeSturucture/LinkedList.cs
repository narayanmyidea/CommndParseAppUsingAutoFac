using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSturucture
{
    public  class Node<T>
    {
        public T Data { get; set; }

        public Node<T> NextNode{ get; set; }
    }
    public sealed class CustomLinkedList1<T>
    {
        private  Node<T> CurrentNode { get; set; }
        private Node<T> HeadNode { get; set; }

        public bool AddAtLast(T item)
        {
            if (HeadNode == null)
            {
                HeadNode=new Node<T>(){Data = item};
                CurrentNode = HeadNode;
            }
            else
            {
                var no=new Node<T>(){Data = item};
                CurrentNode.NextNode = no;
                CurrentNode = no;
            }
            return true;
        }
        public bool AddAtFirst(T item)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node<T>() { Data = item };
                CurrentNode = HeadNode;
            }
            else
            {
                var no = new Node<T>() { Data = item };
                no.NextNode = HeadNode;
                HeadNode = no;
            }
            return true;
        }
        public void Display()
        {
            var p = HeadNode;
            while (p!=null)
            {
                Debug.WriteLine(p.Data);
                p = p.NextNode;
            }
        }
    }
}
