using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSturucture
{
    [Description("This is stack class. operations push,pop")]
    public class Stack<T>
    {
        private T[] _array;
        private int _currentIndex = 0;
        private int _elementCounter = 0;
        private int _fixedLength = 4;
        //class stack
        public Stack()
        {
            _array = new
                T[0];
        }

        public bool Push(T item)
        {
            if (_currentIndex == _elementCounter)
            {

                //T[] temp=new T[_currentIndex+_length];
                Array.Resize(ref _array, _currentIndex + _fixedLength);
                _elementCounter = _currentIndex + _fixedLength;
                //System.Array.Copy(_array,temp, _currentIndex);
                //_array = temp;

            }

            _array[_currentIndex++] = item;
            return true;
        }
        public T Pop()
        {
            if (_currentIndex == 0)
            {
                throw new OverflowException("Under flow");
            }
            T item = _array[--_currentIndex];
            _array[_currentIndex] = default(T);
            var diff = _elementCounter - _currentIndex;
            if (diff >= _fixedLength)
            {
                Array.Resize(ref _array, _currentIndex - 1);
                _elementCounter = _currentIndex;
            }
            return item;
        }
        public void Print()
        {
            if (_currentIndex == 0)
            {
                throw new OverflowException("Under flow");
            }

            for (int j = (_currentIndex - 1); j >= 0; j--)
            {
                Console.Write(_array[j] + " ");
            }
        }
    }
}
