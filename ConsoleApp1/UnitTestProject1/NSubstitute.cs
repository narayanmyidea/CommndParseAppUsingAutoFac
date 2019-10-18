using NUnit.Framework;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestFixture]
    public class NSubstituteExample
    {
        [Test]
        public void MeTest()
        {
            //var calc = Substitute.For<ICalculator>().Add("","","").ReturnsForAnyArgs(x=>"Hello" +x.);



        }
      
    }
    public interface ICalculator
    {
        string Add(int a, int b,string s);
        string Mode { get; set; }
        event EventHandler PoweringUp;
    }
}
