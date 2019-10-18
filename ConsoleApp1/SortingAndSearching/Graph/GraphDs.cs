using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching.Graph
{
    public class GraphDs
    {
        //https://www.koderdojo.com/blog/breadth-first-search-and-shortest-path-in-csharp-and-net-core
        private Dictionary<int,HashSet<int>> adjecencyList=new Dictionary<int, HashSet<int>>();

        public GraphDs()
        {
            //adjecencyList.Add(1, new HashSet<int>() { 2, 3 });
            AddVertics(1);
            AddEdge(new Tuple<int, int>(1,2));
            AddEdge(new Tuple<int, int>(1, 3));
            adjecencyList.Add(2, new HashSet<int>() { 1,4 });

            adjecencyList.Add(3, new HashSet<int>() { 1, 5,6 });

            adjecencyList.Add(4, new HashSet<int>() { 2,7 });

          
            adjecencyList.Add(7, new HashSet<int>() { 5,4 });

            adjecencyList.Add(6, new HashSet<int>() {3,5});

            adjecencyList.Add(5, new HashSet<int>() { 3, 6, 7 ,8});

            adjecencyList.Add(8, new HashSet<int>() { 5,9,10 });

            adjecencyList.Add(9, new HashSet<int>() { 8,10});

            adjecencyList.Add(10, new HashSet<int>() { 8,9 });

        }

        public void AddVertics(int vertic)
        {
            adjecencyList.Add(vertic,new HashSet<int>());
        }

        public void AddEdge(Tuple<int,int> edge)
        {
            //edge.
            adjecencyList[edge.Item1].Add(edge.Item2);
        }

        public void DFSWithoutRecursion(int startNode)
        {
            HashSet<int> visited=new HashSet<int>();
            Stack<int> meStack=new Stack<int>();
            meStack.Push(startNode);

            while (meStack.Any())
            {
                var popped = meStack.Pop();

                if (visited.Contains(popped))
                    continue;

                visited.Add(popped);
                Console.WriteLine(popped);
                var list = adjecencyList[popped];
                foreach (var v in list)
                {
                    if (!visited.Contains(v))
                        meStack.Push(v);
                }
            }
        }

        public void DFSWithRecursion(int startNode,HashSet<int> visitedSet)
        {
            if (visitedSet.Contains(startNode))
                return;
            Console.WriteLine(startNode);
            visitedSet.Add(startNode);
            var sublist= adjecencyList[startNode];
            foreach (var v in sublist)
            {
                if (!visitedSet.Contains(v))
                {
                    DFSWithRecursion(v, visitedSet);
                }
            }
        }
        public void BFS(int startNode)
        {
            HashSet<int> visitedSet = new HashSet<int>();
            Queue<int> meQueue=new Queue<int>();
            meQueue.Enqueue(startNode);
            while (meQueue.Any())
            {
                int value = meQueue.Dequeue();
                if (visitedSet.Contains(value))
                {
                    continue;
                }
                Console.WriteLine(value);
                visitedSet.Add(value);
                HashSet<int> list=new HashSet<int>();
                adjecencyList.TryGetValue(value, out list);
                foreach (var v in list)
                {
                    if (!visitedSet.Contains(v))

                    {
                        meQueue.Enqueue(v);
                    }
                }
            }
        }
    }
}
