using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public interface IRepository<T,TKey>
    {
        T Add(T p);
        T Get(TKey key);
        T Update(TKey k, T p);
    }

    public class Person: IRepository<Person,string>
    {
        public Person Add(Person p)
        {
            return null;
        }
        public Person Get(string key)
        {
            return null;
        }
        public Person Update(string k,Person p)
        {
            return null;
        }
    }
    public class School : IRepository<School, int>
    {
        public School Add(School p)
        {
            return null;
        }
        public School Get(int key)
        {
            return null;
        }
        public School Update(int k, School p)
        {
            return null;
        }
    }
}
