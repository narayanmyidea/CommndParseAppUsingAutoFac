using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching.SearchAlorithms
{
    public class BinarySearch
    {
        public static void BinarySearchMethod()
        {
            Random rnd = new Random(3);
            int[] array = new int[100000];
            for (int i = 0; i < 100000; i++)
            {
                array[i] = rnd.Next(1, 100000);
            }
            Array.Sort(array);
            Console.WriteLine("Array Elements are: ");
          
            //foreach (var l in array)
            //{
            //    Console.Write(l + " ");
            //}

            Console.WriteLine();
            Console.WriteLine("Best case search. Searching for '{0}', Result is '{1}: ",array[0], Search(array,array[0]));
            Console.WriteLine();
            Console.WriteLine("Worst case search. Searching for '{0}', Result is '{1}: ", array[array.Length-1], Search(array, array[array.Length - 1]));


            //Console.WriteLine();
            //Console.WriteLine("Worst case search. Searching for '{0}', Result is '{1}: ", 1, Search(array, 1));
        }
        private static bool Search(int[] array, int number)
        {
            bool found = false;
            int minIndex = 0, maxIndex = array.Length - 1,mid,iteration=0;
            while (minIndex<=maxIndex)
            {
                iteration++;

                mid =( minIndex + maxIndex) / 2;
                if (number == array[mid])
                {
                    found = true;
                    break;

                }
                else if (number >array[mid])
                {
                    minIndex = mid + 1;
                }
                else if (number < array[mid])
                {
                    maxIndex = mid - 1;
                }

            }
            Console.WriteLine(" no of iteration = "+ iteration);
            return found;
        }

        public static void RecusiveStyle(int[] array, int number)
        {
            Console.WriteLine("Array Elements are: ");
            for (int i = 0; i <array.Length; i++)
            {
                Console.WriteLine(array[i] +" ");
            }

            SearchRecursion(array, number);
        }

        public static void SearchRecursion(int[] array, int number)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("not found");
                return;
            }
            int middle = array.Length / 2;
            if (array[middle] == number)
            {
                Console.WriteLine("found");
                return;
            }
            else if( number> array[middle])//
            {
                int h = array.Length - middle;
                int[] v=new int[h];
                Array.Copy(array,v,h);
                SearchRecursion(v, number);
            }
            else
            {
                int h = middle;
                int[] v = new int[h];
                Array.Copy(array, v, h);
                SearchRecursion(v, number);
            }
        }
    }
}
