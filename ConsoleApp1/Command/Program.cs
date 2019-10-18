using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Command
{

    class Program
    {
        static void Main(string[] args)
        {

            Console.Read();
        }
    }

    public class GenericLinkList<T> where T:struct
    {
        private class Node<T>
        {
            public T Data { get; set; }
            public Node<T> NextNode { get; set; }
        }
        private Node<T> _headNode = null;
        private Node<T> _currentNode = null;
        public void AddToHead(T data)
        {
            if (_headNode == null)
            {
                _currentNode = new Node<T>(){Data = data};
                _headNode = _currentNode;

            }
            else
            {
                var node = new Node<T>() {Data = data};
                node.NextNode = _headNode;
                _headNode = node;
            }
        }
        public void AddToTail(T data)
        {
            if (_headNode == null)
                AddToHead(data);
            else
            {
                var node = new Node<T>() { Data = data };
                _currentNode.NextNode = node;
                _currentNode = node;
            }
        }

        public IEnumerable<T> GetEnumerator()
        {
            List<T> list=new List<T>();
            Node<T> node = _headNode;
            while (node != null)
            {
                list.Add(node.Data);
                node = node.NextNode;
            }

            return list;
        }

    }
    public class EventBroker
    {
        //private List<Action<EventArgs>> _eventSource=new List<Action<EventArgs>>();
        private List<object> _eventSource = new List<object>();

        public void Subscribe<T>(Action<T> arg) where T : EventArgs
        {
            _eventSource.Add(arg);
        }

        public void Publish<T>(T args) where T:EventArgs
        {
          
           var action=_eventSource.FirstOrDefault(k => k is Action<T>);
            if (action != null)
            {
                Action<T> selectedAction = action as Action<T>;
                selectedAction(args);
            }

        }
    }
    public class School
    {
        private readonly EventBroker _broker = null;
        public School(EventBroker broker)
        {
            _broker = broker;
          
        }
        public void DoStudentAdmission()
        {
            var studentAdmissionJustDone = new StudentAdmissionEventArgs() {StudentName = "Narayan"};
            Console.WriteLine($"Student:{studentAdmissionJustDone.StudentName} admission is in progress");
            //admission procedure takes some time 

            //once complted, notify student that his admission completed
            _broker.Publish<StudentAdmissionEventArgs>(studentAdmissionJustDone);
        }
    }
    public class Student
    {
        private readonly EventBroker _broker = null;

        public Student(EventBroker broker)
        {
            _broker = broker;
            _broker.Subscribe<StudentAdmissionEventArgs>(NotifyAdmission);
        }
        public void NotifyAdmission(StudentAdmissionEventArgs student)
        {
            Console.WriteLine($"Hi {student.StudentName}. Your admission is completed!");
        }
    }

    public class StudentAdmissionEventArgs : EventArgs
    {
        public string StudentName { get; set; }
    }
}


