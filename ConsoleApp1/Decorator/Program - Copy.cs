using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            //ICoffieDecorator decorator = new ChacolateDecorator(new MilkDecorator(new Esperrio()));
            //decorator.Display();

            //ICoffieDecorator decorator1 = new MilkDecorator(new Esperrio());
            //decorator1.Display();

            //Console.ReadLine();
        }

        public interface ICoffie
        {
            string Name { get; set; }
            double GetPrice();
        }

        public class Filtered : ICoffie
        {
            public string Name { get; set; } = "Filtred";
            public double GetPrice()
            {
                return 10;
            }


        }

        public class Esperrio : ICoffie
        {
            public string Name { get; set; } = "Esperrio";


            public double GetPrice()
            {
                return 5;
            }
        }

        public abstract class ICoffieDecorator : ICoffie
        {
            public abstract string Name { get; set; }
            public double GetPrice()
            {
                return _coffie.GetPrice() + Price;
            }

            public abstract double Price { get; set; }

            private ICoffie _coffie { get; set; }

            public ICoffieDecorator(ICoffie coffie)
            {
                _coffie = coffie;
            }
            public void Display()
            {
                Console.WriteLine("Cost is :" + (GetPrice()));
            }
        }
        public class MilkDecorator : ICoffieDecorator
        {
            public MilkDecorator(ICoffie coffie) : base(coffie)
            {

            }

            public override string Name { get; set; } = "Milk";
            public override double Price { get; set; } = 1.5;
        }
        public class ChacolateDecorator : ICoffieDecorator
        {
            public ChacolateDecorator(ICoffie coffie) : base(coffie)
            {

            }

            public override string Name { get; set; } = "Chacolate";
            public override double Price { get; set; } = 2;
        }
    }




}
