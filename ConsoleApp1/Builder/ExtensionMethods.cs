using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public class Student
    {
        public int Id { get; set; }

        public string Name{ get; set; }

        private int hhhhhhhhh { get; set; }
        public override string ToString()
        {
            return base.ToString()+" This is custom class";
        }

        public string SayHi()
        {
            return "Hi";
        }
    }

    public interface MyInterface1
    {
        void Method1();
    }

    
    
}
