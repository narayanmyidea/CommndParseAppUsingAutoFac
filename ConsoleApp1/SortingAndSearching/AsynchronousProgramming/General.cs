using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAndSearching.AsynchronousProgramming
{
    class General
    {
        public static void Task_Based_AsynchronousPattern()
        {

        }
        
    }
    public class MyCustomBackGroundWorker
    {
        private NarayanBackGroundWorker _backgroundWorker = null;
        private Action<int> _callAction;
        public MyCustomBackGroundWorker(Action<int> callAction)
        {
            _backgroundWorker = new NarayanBackGroundWorker();
            _backgroundWorker.DoWorkHandler += _backgroundWorker_DoWork;
            _backgroundWorker.DoWorkComplted += _backgroundWorker_RunWorkerCompleted;
            Console.WriteLine("starting Thread " + Thread.CurrentThread.ManagedThreadId);
            _callAction = callAction;
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, NarayanBackGroundWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Completed Thread " + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("IS it main Thread " + !Thread.CurrentThread.IsThreadPoolThread);
        }

        public void StartWorker()
        {
            _backgroundWorker.RunAsync("Narayan");
        }
       
        private void _backgroundWorker_DoWork(object sender, NarayanBackGroundWorkerEventArgs e)
        {
            Console.WriteLine("Background Thread " + Thread.CurrentThread.ManagedThreadId);
            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(1000);
                _callAction(i);
            }
        }
    }
    public class MyBackGroundWorker
    {
        private BackgroundWorker _backgroundWorker = null;
        private Action<int> _callAction;
        public MyBackGroundWorker(Action<int> callAction)
        {
            _backgroundWorker=new BackgroundWorker();
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            Console.WriteLine("starting Thread "+Thread.CurrentThread.ManagedThreadId);
           _callAction = callAction;
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Completed Thread " + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("IS it main Thread " + !Thread.CurrentThread.IsThreadPoolThread);
        }

        public void StartWorker()
        {
            _backgroundWorker.RunWorkerAsync("Narayan");
        }
        public void StopWorker()
        {
            _backgroundWorker.CancelAsync();
        }
        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("Background Thread " + Thread.CurrentThread.ManagedThreadId);
            BackgroundWorker worker = sender as BackgroundWorker;
            
            for (int i = 1; i <= 5; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                Thread.Sleep(1000);
                _callAction(i);
            }
        }
    }

    public delegate void DoWorkDel(object sender, NarayanBackGroundWorkerEventArgs argument);
    public delegate void WorkCompleted(object sender, NarayanBackGroundWorkerCompletedEventArgs argument);
    public class NarayanBackGroundWorker
    {
        public event DoWorkDel DoWorkHandler;
        public event WorkCompleted DoWorkComplted;
        public event Action<int> ReportProgress;
        public void RunAsync(object o)
        {
            NarayanBackGroundWorkerEventArgs param = new NarayanBackGroundWorkerEventArgs() {Argument = o};
            DoWorkHandler(this, param);

            NarayanBackGroundWorkerCompletedEventArgs re = new NarayanBackGroundWorkerCompletedEventArgs()
                {Cancelled = false};

            DoWorkComplted(this, re);
        }
    }

    public class NarayanBackGroundWorkerEventArgs : EventArgs
    {
        public object Argument { get; set; }
    }
    public class NarayanBackGroundWorkerCompletedEventArgs : EventArgs
    {
        public object Result { get; set; }
        public bool Cancelled { get; set; }
    }

}
