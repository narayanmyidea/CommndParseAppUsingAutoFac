using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching.Sorting
{
    //Best time complexity=O(N)=OMEGA
    //Worst case time complexity=O(N) * sqaure=BIG(O) or Theta
    public class BubleSort
    {

        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i=i + 1)
            {
                bool swapped = false;
                for (int j = 0; j < array.Length - 1; j = j + 1)
                {
                    if (array[j + 1] < array[j])
                    {
                        var temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                        swapped = true;
                    }
                }

                
                Console.WriteLine("After "+(i+1)+" Iteration ");
                for (int m = 0; m < array.Length; m++)
                {
                    Console.Write(array[m] + " ");
                }
                Console.WriteLine();
                if (!swapped)
                {
                    break;
                }
            }

            Console.WriteLine("Final ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }
            
        }
    }
}
