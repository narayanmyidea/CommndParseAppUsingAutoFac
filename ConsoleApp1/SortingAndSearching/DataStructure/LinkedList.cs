using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching.DataStructure
{
    public class CustomLinkedList<T>
    {
        Node _headNode = null;
        Node _lastNode = null;
        class Node
        {
            public T data { get; set; }
            public Node NextNode { get; set; }
        }

        public void AddLast(T item)
        {
            if (_headNode == null)
            {
                var node = new Node() {data = item, NextNode = null};
                _headNode = node;
                _lastNode = node;
            }
            else
            {
           
                var node = new Node() { data = item, NextNode = null };
                _lastNode.NextNode = node;
                _lastNode = node;
            }
        }

        public void AddToHead(T item)
        {
            if (_headNode == null)
            {
                _headNode = new Node() {data = item};
                _lastNode = _headNode;
            }
            else
            {
                var node = new Node() {data = item, NextNode = _headNode};
                _headNode = node;
            }

        }

        public void Print()
        {
            Node node = _headNode;
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.NextNode;
            }
        }
    }

    public class CustomQueue//First In First out
    {
        private int _rear = 0, _front = 0,_size = 0;
        private int[] queueList = null;
        public CustomQueue(int size)
        {
            _size = size;
            queueList=new int[_size];
        }

        public void Enqueue(int item)
        {
            if (_rear == _size)
            {
                Console.WriteLine("Overflow");
            }
            queueList[_rear++]=item;

        }
        public int Deueue()
        {
            if (_front > _rear || _front==_size)
            {
                Console.WriteLine("Underflow");
                return 0;
            }

            var inde = _front++;
            var item = queueList[inde];

            queueList[inde] = 0;
            return item;
        }

    }
}
