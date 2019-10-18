using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Builder;
using ExtensionMethods;

namespace TreeSturucture
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Read();
            //Graph g = new Graph(7, true);
            //g.AddEdge(0, 1);
            //g.AddEdge(0, 2);
            //g.AddEdge(0, 3);
            //g.AddEdge(1, 0);
            //g.AddEdge(1, 5);
            //g.AddEdge(2, 5);
            //g.AddEdge(3, 0);
            //g.AddEdge(3, 4);
            //g.AddEdge(4, 6);
            //g.AddEdge(5, 1);
            //g.AddEdge(5, 6);//
            //g.AddEdge(6, 5);

            //Console.Write("Breadth First Traversal from vertex 2:\n");
            //g.BreadthFirstSearch(2);


            int yy = 0;
            //// List<int>[] v=new List<int>[2];
            //double[] d = new Double[2];

            // foreach (string x in GetDemoEnumerable())
            // {
            //     Console.WriteLine(x);
            // }

            // int[] arr = new int[] {4, 3, 1,8,5};
            // Console.WriteLine("Before Sorting");
            // Print(arr);

            // ISortAlgorithm sortAlgo = null;
            // //sortAlgo = new SelectionSort();
            // sortAlgo=new InsertionSort();
            // sortAlgo.Sort(ref arr);

            // Console.WriteLine("After Sorting");
            // Print(arr);
            Console.Read();

        }

        private static void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("complted thread id" + Thread.CurrentThread.ManagedThreadId);
        }

        private static void Bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("progress change thread id" + Thread.CurrentThread.ManagedThreadId);
        }

        private static void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            var _bw = sender as BackgroundWorker;
            Console.WriteLine("do work thread id"+Thread.CurrentThread.ManagedThreadId);
            for(int i=10;i<100;i=i+10)
            {
                if (_bw.CancellationPending) { e.Cancel = true; return; }
                Thread.Sleep(1000);
                var b = sender as BackgroundWorker;
                b.ReportProgress(10);
            }
        }

        static void Print(int[] arr)
        {
            for (int l = 0; l < arr.Length; l++)
            {
                Console.WriteLine(arr[l]);
            }
        }

        static IEnumerable<string> GetDemoEnumerable()
        {
            yield return "start";

            for (int i = 0; i < 5; i++)
            {
                yield return i.ToString();
            }

            yield return "end";
        }
    }

 
}
