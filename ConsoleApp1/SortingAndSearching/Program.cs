using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using SortingAndSearching.AsynchronousProgramming;
using SortingAndSearching.SearchAlorithms;
using SortingAndSearching.Sorting;
using IntPtr = System.IntPtr;

namespace SortingAndSearching
{
    //Write a program to identify time taken to sum the array ,avg the array sequenctiol vs parralel

    class Program
    {
        static void Main(string[] args)
        {
            short s = -10;

            int[] arr = {1,2,3,4,5};
            for (int k = 0; k <arr.Length-1;k++)
            {
                for (int r = k+1; r < arr.Length; r++)
                {
                    if (arr[r] > arr[k])
                    {
                        var temp = arr[k];
                        arr[k] = arr[r];
                        arr[r] = temp;
                        
                    }
                }
                //After Ist Iteration
                Console.WriteLine();
                Console.WriteLine("After "+(k+1)+ " Iteration");
                foreach (var v in arr)
                {
                    Console.Write(v);
                }
            }
            Console.Read();
        }

    }
}
