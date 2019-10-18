using NUnit.Framework;
using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSturucture;
namespace UnitTestProject1
{
    [NUnit.Framework.Ignore("")]
    [TestFixture]
    class LinkedListTest
    {
        [Test]
        public void FF()
        {
            //arrange 
            CustomLinkedList1<string> lstLinkedList = new CustomLinkedList1<string>();

            //act
            lstLinkedList.AddAtFirst("word a");
            lstLinkedList.AddAtFirst("word b");
            lstLinkedList.AddAtFirst("word c");
            lstLinkedList.AddAtFirst("word d");
            lstLinkedList.AddAtFirst("word e");

            lstLinkedList.Display();
            //Assert
            //
        }
    }
}
