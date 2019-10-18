using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//using System.Timers;


namespace Threading
{
    class Program
    {
        
        private static ThreadLocal<int> _xx = new ThreadLocal<int>(()=>10);

        static void Main(string[] args)
        {
            Program o=new Program();
            Thread th = new Thread(new ParameterizedThreadStart(o.set));
            th.Start(1);
            LocalDataStoreSlot dd = Thread.GetNamedDataSlot("DDD");

             Thread th2 = new Thread(new ParameterizedThreadStart(o.set));
            th2.Start(2);

            Thread th3 = new Thread(new ParameterizedThreadStart(o.set));
            th3.Start(3);

            th.Join();
            th2.Join();
            th3.Join();
            Console.WriteLine("xx value is"+_xx);
            Console.Read();
        }

        public void set(object o)
        {
           
            Thread.Sleep(2000);
            Console.WriteLine("Current thread passed value :"+o+" xx "+_xx);
        }
       
    }
   
    public class TakeFingerPrintFromDevice
    {
        public void Capture(object o)
        {
            ManualResetEvent au = o as ManualResetEvent;
            Console.WriteLine("Please wait.. we are screening your finger prints");
            Thread.Sleep(2000);
           // au.Set();
           
        }
        public void Sample(object o)
        {
            ManualResetEvent au = o as ManualResetEvent;
            Console.WriteLine("Sample Method is waiting for finger print to complte");

            au.WaitOne();
            Console.WriteLine("Sample Method executed");
            
        }

    }
    public class StudentUsingMonitor
    {
        public int Count { get; set; }
        public object obj=new object();
        public void PrintCount()
        {
            bool lockObtained =false;


            try
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is trying to gain control");
                Monitor.TryEnter(obj,200, ref lockObtained);
                if (lockObtained)
                {

                    while (Count++ < 10)
                    {
                        Thread.Sleep(50);
                        if (Count == 4)
                            throw new Exception("DSSDFSDF");
                        Console.WriteLine(Count);
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is processing");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} cought exception");
            }
            finally
            {
                if (lockObtained)
                {
                    Monitor.Exit(obj);
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} got lock");
                }
                else
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} did not get lock");
                }
            }

        }

    }
    class StatusChecker
    {
        private int invokeCount;
        private int maxCount;

        public StatusChecker(int count)
        {
            invokeCount = 0;
            maxCount = count;
        }

        // This method is called by the timer delegate.
        public void CheckStatus(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            Console.WriteLine("{0} Checking status {1,2}.",
                DateTime.Now.ToString("h:mm:ss.fff"),
                (++invokeCount).ToString());

            if (invokeCount == maxCount)
            {
                // Reset the counter and signal the waiting thread.
                invokeCount = 0;
                autoEvent.Set();
            }
        }
    }

  
}
