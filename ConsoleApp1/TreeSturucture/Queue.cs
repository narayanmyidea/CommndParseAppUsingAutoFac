using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSturucture
{
    [Description("This is Queue class")]
    public class Queue<T>
    {
        private T[] _array;
        private int _rear = 0;
        private int _front = 0;
        private int _length = 0;
        public Queue(int length)
        {
            _array = new T[length];
            _length = length;
        }

        public bool Enqueue(T item)
        {
            if (_rear >= _length)
            {
                Console.WriteLine("Queue overflow");
                return false;
            }
            _array[_rear++] = item;
            return true;
        }

        public bool Dequeue()
        {
            if (_front >= _rear)
            {
                Console.WriteLine("Queue underflow");
                return false;
            }

            _array[_front++] = default(T);
            return true;
        }
    }
}
