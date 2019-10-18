using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class Iterator
    {
        public void MentainStateCheckForCustomIterator(Student[] kk)
        {
            // IMyIterator<Student> hh=new MyIterator<Student>(kk);
            //IEnumerable<Student> o = kk;
            //var uu = o.GetEnumerator();
            //while (uu.MoveNext())
            //{
            //    Console.WriteLine("============================");
            //    Console.WriteLine(uu.Current.Name);
            //    var nn = o.GetEnumerator();
            //    while (nn.MoveNext())
            //    {
            //        Console.WriteLine(nn.Current.Name);
            //    }
            //    Console.WriteLine("============================");
            //}
            MyIteratorEnumaration<Student> o =new MyIteratorEnumaration<Student>(kk);
            var uu = o.GetMyIterator;
            while (uu.MoveNext())
            {
                Console.WriteLine("============================");
                Console.WriteLine(uu.Current.Name);
                var nn = o.GetMyIterator;
                while (nn.MoveNext())
                {
                    Console.WriteLine(nn.Current.Name);
                }
                Console.WriteLine("============================");
            }

        }

        public void MentainStateCheck(Student[] kk)
        {
            var studentList = kk.ToList();
            //for (int i = 0; i < studentList.Count; i++)
            //{
            //    Console.WriteLine("============================");
            //    Console.WriteLine(studentList[i].Name);
            //    for (int j = 0; j < studentList.Count; j++)
            //    {
            //        Console.WriteLine(studentList[j].Name);
            //    }
            //    Console.WriteLine("============================");
            //}

            foreach (var student in studentList)
            {
                Console.WriteLine("============================");
                Console.WriteLine(student.Name);
                foreach (var st in studentList)
                {
                    Console.WriteLine(st.Name);
                }
                Console.WriteLine("============================");
            }


        }
    }
}
