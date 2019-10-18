using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    public class QuickSortExample
    {
        public static void QuickSort(ref int[] array)
        {
            Console.WriteLine("Before quick Sort,Array Elements are: ");
            Console.WriteLine();
            foreach (var l in array)
            {
                Console.Write(l + " ");
            }

            QuickSort(array,0, 4);
            Console.WriteLine();
            Console.WriteLine("After quick Sort,Array Elements are: ");
            Console.WriteLine();
            foreach (var l in array)
            {
                Console.Write(l + " ");
            }
        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(arr, start, end);

                QuickSort(arr, start, i - 1);
                QuickSort(arr, i + 1, end);
            }
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int temp;
            int p = arr[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (arr[j] <= p)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            return i + 1;
        }
    }
}
