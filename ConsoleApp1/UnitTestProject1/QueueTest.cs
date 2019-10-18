using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TreeSturucture;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace UnitTestProject1
{
    
    [NUnit.Framework.Ignore("")]
    [TestFixture]
    public class QueueTest
    {
        private Queue<char> queue;
        
        [Test]
        public void QueueTest_EnQueue_ShouldReturnFalse_WhenQueueLength_Zero()
        {
            //arrange
            queue=new Queue<char>(0);

            //act
            var val=queue.Enqueue('A');

            //assert
            Assert.AreEqual(false,val);
        }
        [Test]
        public void QueueTest_EnQueue_ShouldReturnFalse_OverQueueLength()
        {
            //arrange
            queue = new Queue<char>(3);

            //act
            queue.Enqueue('A');//0
            queue.Enqueue('B');//1
            queue.Enqueue('C');//2
            var val = queue.Enqueue('D');//2
            //assert
            Assert.AreEqual(false, val);
        }
        [Test]
        public void QueueTest_Enqueue_ShouldReturnTrue_WithinRange()
        {
            //arrange
            queue = new Queue<char>(3);

            //act
            var v1=queue.Enqueue('A');//0
            var v2 = queue.Enqueue('B');//1
            var v3 = queue.Enqueue('C');//2
            
            //assert
            Assert.AreEqual(true, v1);
            Assert.AreEqual(true, v2);
            Assert.AreEqual(true, v3);
        }
        [Test]
        public void QueueTest_Dequeue_ShouldReturnFalse_RangeZero()
        {
            //arrange
            queue = new Queue<char>(0);

            //act
            var v1 = queue.Dequeue();//0
            
            //assert
            Assert.AreEqual(false, v1);
          
        }
        [Test]
        public void QueueTest_Dequeue_ShouldReturnFalse_OutOfZero()
        {
            //arrange
            queue = new Queue<char>(1);

            //act
            queue.Enqueue('A');
            queue.Dequeue();
            var v1 = queue.Dequeue();

            //assert
            Assert.AreEqual(false, v1);

        }

        [Test]
        public void QueueTest_Dequeue_ShouldReturnTrue_WithinRange()
        {
            //arrange
            queue = new Queue<char>(3);

            //act
            queue.Enqueue('A');
            queue.Enqueue('B');
            queue.Enqueue('C');
         
            var v1=queue.Dequeue();
            var v2=queue.Dequeue();
            var v3=queue.Dequeue();
           
            

            //assert
            Assert.AreEqual(true, v1);
            Assert.AreEqual(true, v2);
            Assert.AreEqual(true, v3);

        }
    }
}

