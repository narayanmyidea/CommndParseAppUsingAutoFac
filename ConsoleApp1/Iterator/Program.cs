using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {

            var t = new List<string>() { "BBB", "CCCC" };
            IEnumerable<Object> ss = t;

            var list = getCollection();

            Student j=new Student();
            j.ToString();
            j.ToString("JJJ", null);

            //Iterator o=new Iterator();
            //o.MentainStateCheckForCustomIterator(list);

            
           // Array.Sort(list);
            
           //Array.Sort(list,Student.SortingByIdAsc());

           // Array.Sort(list, Student.SortingByIdDesc());
            Console.Read();
        }

        private static Student[] getCollection()
        {
            Student[] kk = new Student[5];
            kk[0] = new Student() { Name = "Narayan", ID = 1 };
            kk[1] = new Student() { Name = "Kiran", ID = 2 };
            kk[2] = new Student() { Name = "Sagar", ID = 3 };
            kk[3] = new Student() { Name = "Amar", ID = 4 };
            kk[4] = new Student() { Name = "Ravi", ID = 5 };
            return kk;
        }
        
    }

   

    public class Student : IComparable<Student>, IFormattable
    {
       
        public string Name { get; set; }
        public int ID { get; set; }

        public int CompareTo(Student x)//default sort order
        {
           return string.Compare(this.Name, x.Name);

        }

        public static IComparer<Student> SortingByIdDesc()
        {
            return new SortingByIdDescending();
        }
        public static IComparer<Student> SortingByIdAsc()
        {
            return new SortingByIdAscending();
        }

        public override string ToString()
        {
            return this.ToString("Narayan", CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {

            return "DDDDDD";
        }

        private class SortingByIdDescending:IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                if (x.ID > y.ID)
                    return 1;
                if (x.ID < y.ID)
                    return -1;
                else
                {
                    return 0;
                }
            }
        }
        private class SortingByIdAscending : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                if (x.ID < y.ID)
                    return 1;
                if (x.ID > y.ID)
                    return -1;
                else
                {
                    return 0;
                }
            }
        }
    }
    public class MyIteratorEnumaration<T>
    {
        private  MyIterator<T> _iterator = null;
        private readonly T[] _source = null;
        public MyIteratorEnumaration(T[] source)
        {
            _source = source;
        }
        public MyIterator<T> GetMyIterator
        {
            get
            {
                _iterator = new MyIterator<T>(_source);
                return  _iterator;
            }
        }
    }
    public interface IMyIterator<T>
    {
        bool MoveNext();
        T Current { get; }
        void Reset();
    }
    public class MyIterator<T>: IMyIterator<T>
    {
        private readonly T[] _dataSource = null;
        public MyIterator(T[] source)
        {
            _dataSource = source;
        }

        private int _currentIndex = -1;
        public bool MoveNext()
        {
            _currentIndex++;
            if (_dataSource.Length == _currentIndex)
            {
                return false;
            }
         
            return true;
        }
        public T Current
        {
            get { return _dataSource[_currentIndex]; }
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }
}
