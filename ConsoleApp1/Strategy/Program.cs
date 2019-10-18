using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> prods=new List<Product>(5);
            SortContext<Product> p=new SortContext<Product>(); 
            p.Sort(prods,sortTypes.OPPP);
            Console.Read();
        }
    }

    enum sortTypes { Merge,Quick,Heap,OPPP}
    
    interface ISort<T>
    {
        void sort(List<T> collection);
    }
    class SortContext<T>
    {
        private IDictionary<sortTypes, ISort<T>> dictionary = new Dictionary<sortTypes, ISort<T>>();

        public SortContext()
        {
            dictionary.Add(sortTypes.Heap, new HeapSort<T>());
            dictionary.Add(sortTypes.Merge, new MergeSort<T>());
            dictionary.Add(sortTypes.Quick, new QuickSort<T>());
        }
        public void Sort(List<T> collection, sortTypes strategySort)
        {
            Console.WriteLine("Sorting begun");
            ISort<T> sort = null;
            dictionary.TryGetValue(strategySort, out sort);
            if (sort == null)
            {
                throw  new NotImplementedException();
            }
            sort.sort(collection);
            Console.WriteLine("Sorting completed");
        }
    }

    public class MergeSort<T> : ISort<T>
    {
        public void sort(List<T> collection)
        {
          Console.WriteLine("This is merge sort");
        }
    }
    public class QuickSort<T> : ISort<T>
    {
        public void sort(List<T> collection)
        {
            Console.WriteLine("This is quick sort");
        }
    }
    public class HeapSort<T> : ISort<T>
    {
        public void sort(List<T> collection)
        {
            Console.WriteLine("This is heap sort");
        }
    }

    class  Product
    {
        
    }
}
