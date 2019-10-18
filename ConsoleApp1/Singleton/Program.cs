using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//http://csharpindepth.com/articles/general/singleton.aspx
namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //Product p=new Product();
            Product.GGGG();
        }
    }

    public class Product
    {
         private static readonly Lazy<Product> instace=new Lazy<Product>();

        public static Lazy<Product> GetInstance
        {
            get { return instace; }
        }

        public static void GGGG()
        {

        }
    }
}

