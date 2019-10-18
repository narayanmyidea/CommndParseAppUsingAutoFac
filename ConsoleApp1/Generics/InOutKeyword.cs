using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public interface IInOutKeyword<in T,out V>
    {
        V GetMe();
        V GetMe(T args);
    }

    public class InOutKeyword : IInOutKeyword<string, int>
    {
        public int GetMe()
        {
            throw new NotImplementedException();
        }

        public int GetMe(string args)
        {
            throw new NotImplementedException();
        }
    }
}
