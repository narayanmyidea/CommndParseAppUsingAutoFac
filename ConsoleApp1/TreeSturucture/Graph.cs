using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSturucture
{
    /// <summary>
    /// Vertex Structure
    /// </summary>
    class Graph
    {
        private int _V;
        private bool _directed;
        LinkedList<int>[] _adj;

        public Graph(int V, bool directed)
        {
            _adj = new LinkedList<int>[V];

            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new LinkedList<int>();
            }

            _V = V;
            _directed = directed;
        }

        public void AddEdge(int v, int w)
        {
            _adj[v].AddLast(w);

            if (!_directed)
            {
                _adj[w].AddLast(v);
            }
        }

        public void BreadthFirstSearch(int s)
        {
            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;

            // Create a queue for BFS
            LinkedList<int> queue = new LinkedList<int>();

            visited[s] = true;
            queue.AddLast(s);
            //0 ->1,2,3
            //
            while (queue.Any())
            {
                // Dequeue a vertex from queue and print it
                s = queue.First();
                Console.Write(s + " ");
                queue.RemoveFirst();

                LinkedList<int> list = _adj[s];

                foreach (var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.AddLast(val);
                    }
                }
            }
        }

    }

    public class SortMeExample
    {
        //selection sort
        public static void Sort()
        {
            int[] arrya = new[] {3, 5, 9, 44, 1, 7};
            for (int i = 0; i < arrya.Length - 1; i++)
            {
                for (int j = i + 1; j < arrya.Length; j++)
                {
                    if (arrya[i] > arrya[j])
                    {
                        var temp = arrya[i];
                        arrya[i] = arrya[j];
                        arrya[j] = temp;
                    }
                }
            }

        }
        //bubble sort
        public static void BubbleSort()
        {
            int[] arrya = new[] { 3, 5, 9, 44, 1, 7 };
            for (int i = 0; i < arrya.Length; i++)
            {
                for (int j = 0; j < arrya.Length-1; j++)
                {
                    if (arrya[j] > arrya[j + 1])
                    {
                        var t = arrya[j];
                        arrya[j] = arrya[j + 1];
                        arrya[j + 1] = t;
                    }
                }
            }

        }
        public static void InsertionSort()
        {
            int[] arr = new[] { 3, 5, 9, 44, 1, 7 };
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    var t = arr[i ];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = t;

                    for (int j = i; j> 0; j--)
                    {
                        if (arr[j - 1]> arr[j])
                        {
                            var t1 = arr[j];
                            arr[j] = arr[j - 1];
                            arr[j - 1] = t1;
                        }
                    }

                }
            }

        }


    }
}
