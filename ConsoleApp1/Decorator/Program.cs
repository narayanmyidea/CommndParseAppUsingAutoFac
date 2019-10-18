//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Decorator
//{
//    class Program
//    {
//        [STAThread]
//        static void Main()
//        {

//            //Client - code
//            Margherita pizza = new Margherita();
//            Console.WriteLine("Plain Margherita: " + pizza.GetPrice().ToString());

//            ExtraCheeseTopping moreCheese = new ExtraCheeseTopping(pizza);
//            Console.WriteLine("Plain Margherita with single extra cheese: " + moreCheese.GetPrice().ToString());

//            ExtraCheeseTopping someMoreCheese = new ExtraCheeseTopping(moreCheese);
//            Console.WriteLine("Plain Margherita with double extra cheese: " + someMoreCheese.GetPrice().ToString());

//            MushroomTopping moreMushroom = new MushroomTopping(someMoreCheese);
//            Console.WriteLine("Plain Margherita with double extra cheese with mushroom: " + moreMushroom.GetPrice().ToString());

//            JalapenoTopping moreJalapeno = new JalapenoTopping(moreMushroom);
//            Console.WriteLine("Plain Margherita with double extra cheese with mushroom with Jalapeno: " + moreJalapeno.GetPrice().ToString());
//            Console.ReadLine();
//        }
//    }

//    public abstract class BasePizza
//    {
//        protected double myPrice;

//        public virtual double GetPrice()
//        {
//            return this.myPrice;
//        }
//    }

//    public abstract class ToppingsDecorator : BasePizza
//    {
//        public double myPrice { get; set; }
//        protected BasePizza pizza;
//        public ToppingsDecorator(BasePizza pizzaToDecorate)
//        {
//            this.pizza = pizzaToDecorate;
//        }

//        public override double GetPrice()
//        {
//            return (this.pizza.GetPrice() + this.myPrice);
//        }
//    }
//    public class Margherita : BasePizza
//    {
//        public Margherita()
//        {
//            this.myPrice = 6.99;
//        }
//    }

//    public class Gourmet : BasePizza
//    {
//        public Gourmet()
//        {
//            this.myPrice = 7.49;
//        }
//    }

//    public class ExtraCheeseTopping : ToppingsDecorator
//    {
//        public ExtraCheeseTopping(BasePizza pizzaToDecorate)
//            : base(pizzaToDecorate)
//        {
//            this.myPrice = 0.99;
//        }
//    }

//    public class MushroomTopping : ToppingsDecorator
//    {
//        public MushroomTopping(BasePizza pizzaToDecorate)
//            : base(pizzaToDecorate)
//        {
//            this.myPrice = 1.49;
//        }
//    }

//    public class JalapenoTopping : ToppingsDecorator
//    {
//        public JalapenoTopping(BasePizza pizzaToDecorate)
//            : base(pizzaToDecorate)
//        {
//            this.myPrice = 1.49;
//        }
//    }

//}
