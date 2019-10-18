using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching.TreeDataStructure.Traversing
{
    public class MyTreeComponents
    {
        public int Id { get; set; }

        public int ParentId { get; set; }
        public string Name { get; set; }

        public static List<MyTreeComponents> DataSource()
        {
            List<MyTreeComponents> list = new List<MyTreeComponents>();
            list.Add(new MyTreeComponents() {Id = 1, Name = "Parent", ParentId = 0});

            list.Add(new MyTreeComponents() {Id = 10, Name = "Level 1= 2", ParentId = 1});
            list.Add(new MyTreeComponents() { Id = 11, Name = "Level 1= 3 ", ParentId = 1 });


            list.Add(new MyTreeComponents() {Id = 20, Name = "Level 2= 4", ParentId = 11});
            list.Add(new MyTreeComponents() { Id = 21, Name = "Level 2= 5", ParentId = 11 });

            list.Add(new MyTreeComponents() { Id = 30, Name = "Level 3= 6", ParentId = 20 });


            return list;
        }
    }

    public class TreeTraversal
    {
        public static void DepthFirst()
        {
            var lst = MyTreeComponents.DataSource();
            Traverse(lst[0], lst);
        }

        public static void DFSWithoutRecursion()
        {
            var lst = MyTreeComponents.DataSource();
            Stack<MyTreeComponents> mestak=new Stack<MyTreeComponents>();
            mestak.Push(lst[0]);

            while (mestak.Any())
            {
                var p = mestak.Pop();
                Console.WriteLine(p.Name);
                var childern = lst.Where(c => c.ParentId == p.Id).ToList();
                //foreach (var ch in childern)
                //{
                //    mestak.Push(ch);
                //}
                for (int i = childern.Count()-1; i>=0; i--)
                {
                    mestak.Push(childern[i]);
                }
            }
        }

        public static void Traverse(MyTreeComponents parent, List<MyTreeComponents> list)
        {
            Console.WriteLine(parent.Name);
            var childern = list.Where(c => c.ParentId == parent.Id);
            foreach (var ch in childern)
            {
                Traverse(ch, list);
            }
        }

        public static void BreadthFirst()
        {
            var lst = MyTreeComponents.DataSource();
            BFS(lst[0], lst);

        }

        private static void BFS(MyTreeComponents parent, List<MyTreeComponents> list)
        {
            Queue<MyTreeComponents> meQueue = new Queue<MyTreeComponents>();
            meQueue.Enqueue(parent);
            while (meQueue.Any())
            {
                var item = meQueue.Dequeue();
                Console.WriteLine(item.Name);
                var childern = list.Where(c => c.ParentId == item.Id);
                foreach (var ch in childern)
                {
                    meQueue.Enqueue(ch);
                }
            }
        }
    }
}
