using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching.Sorting
{
    //Best time complexity=O(N)=OMEGA
    //Worst case time complexity=O(N) * sqaure=BIG(O) or Theta
    public class SelectionSort
    {
        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = i + 1; j < array.Length ; j++)
                {
                    if(array[i] > array[j])
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
                Console.WriteLine("After " + (i + 1) + " Iteration ");
                for (int m = 0; m < array.Length; m++)
                {
                    Console.Write(array[m] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Final ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
