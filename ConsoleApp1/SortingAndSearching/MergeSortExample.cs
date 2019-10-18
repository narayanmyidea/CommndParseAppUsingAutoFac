using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Array = System.Array;

namespace SortingAndSearching
{
    public class MergeSortExample
    {
        public static void MergeSort(ref int[] array)
        {
            Console.WriteLine("Before Merge Sort,Array Elements are: ");
            Console.WriteLine();
            foreach (var l in array)
            {
                Console.Write(l + " ");
            }
            var sortedList=splitArray(array);
            Console.WriteLine();
            Console.WriteLine("After Merge Sort,Array Elements are: ");
            Console.WriteLine();
            foreach (var l in sortedList)
            {
                Console.Write(l + " ");
            }
           

        }

        private static void MergeTwoArray(List<int> array, List<int> leftArray, List<int>rightArray)
        {
            while (leftArray.Count > 0 || rightArray.Count > 0)
            {
                if (leftArray.Count > 0 && rightArray.Count > 0)
                {
                    if (leftArray[0] <= rightArray[0])
                    {
                        array.Add(leftArray[0]);
                        leftArray.Remove(leftArray[0]);
                    }
                    else
                    {
                        array.Add(rightArray[0]);
                        rightArray.Remove(rightArray[0]);
                    }
                }
                else
                {
                    if (leftArray.Count > 0)
                    {
                        array.Add(leftArray[0]);
                        leftArray.Remove(leftArray[0]);
                    }
                    else if (rightArray.Count > 0)
                    {
                        array.Add(rightArray[0]);
                        rightArray.Remove(rightArray[0]);
                    }
                }
            }
        }
        public static List<int> splitArray(int[] arr)
        {
            if (arr.Length <= 1)
                return arr.ToList();

            var halfArray = arr.Length / 2;
            var leftArray = new int[halfArray];
            var rightArray = new int[halfArray];
            

            Array.Copy(arr, 0,leftArray,0, halfArray);

            if (arr.Length % 2 == 0)
                Array.Copy(arr, halfArray, rightArray,0,halfArray);
            else
            {
                rightArray = new int[halfArray+1];
                Array.Copy(arr, halfArray, rightArray, 0, halfArray +1);
            }


            leftArray=splitArray(leftArray).ToArray();
            rightArray=splitArray(rightArray).ToArray();
            List<int> list=new List<int>();
             MergeTwoArray(list, leftArray.ToList(), rightArray.ToList());
             return list;
        }

    }
}
