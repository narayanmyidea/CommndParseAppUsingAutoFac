using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeSturucture
{
  
    public class Component
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }

        public static List<Component> GetSampleComponents()
        {
            List<Component> compsList=new List<Component>();
            compsList.Add(new Component(){Name = "Parent",Id = 1,ParentId = 0});

            compsList.Add(new Component() { Name = "Child 1", Id = 10, ParentId = 1 });
            compsList.Add(new Component() { Name = "Child 2", Id = 11, ParentId = 1 });

            compsList.Add(new Component() { Name = "Child 1 child 1", Id = 20, ParentId = 10 });
            compsList.Add(new Component() { Name = "Child 1 child 2", Id = 21, ParentId = 10 });

            compsList.Add(new Component() { Name = "Child 2 child 1", Id = 30, ParentId = 11 });

            compsList.Add(new Component() { Name = "Child 1 child 2 child 1", Id = 31, ParentId = 21 });

            return compsList;
        }

       
        public static void DepthFirstTraversal()
        {
            var p=GetSampleComponents()[0];
            Traverse(p);
        }

        public static void BreadthFirstTraversal()
        {
            Component c = GetSampleComponents()[0];

            System.Collections.Generic.Queue<Component> meQueue=new System.Collections.Generic.Queue<Component>();
            meQueue.Enqueue(c);
            while (meQueue.Any())
            {
                var f = meQueue.Dequeue();
                Console.WriteLine(f.Name);
                var childList = GetSampleComponents().Where(cc => cc.ParentId == f.Id);
                foreach (var v in childList)
                {
                   meQueue.Enqueue(v);
                }
            }
        }
        private static void Traverse(Component parent)
        {
            var childList = GetSampleComponents().Where(c => c.ParentId == parent.Id);
            Console.WriteLine(parent.Name);
            foreach (var v in childList)
            {
                Traverse(v);
            }
        }
    }
}