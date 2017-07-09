using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignLibrary
{
    public class ObserverPattern
    {
        public class Subject
        {
            private const int _speed = 200;
            private Simulator _sim = new Simulator();

            public string SubjectState { get; set; }

            public delegate void Callback(string s);
            public event Callback Notify;

            public void Go()
            {
                new Thread(Run).Start();
            }

            private void Run()
            {
                foreach (string s in _sim)
                {
                    Console.WriteLine("Subject: " + s);
                    SubjectState = s;
                    Notify(s);
                    Thread.Sleep(_speed);
                }
            }
        }

        public interface IObserver
        {
            void Update(string state);
        }

        public class Observer : IObserver
        {
            private string _name;
            private Subject _subject;
            private string _state;
            private string _gap;

            public Observer(Subject subject, string name, string gap)
            {
                _subject = subject;
                _name = name;
                _gap = gap;

                _subject.Notify += Update;
            }

            #region IObserver Members

            public void Update(string subjectState)
            {
                _state = subjectState;
                Console.WriteLine(_gap+_name + ": " + _state);
            }

            #endregion
        }

        public class Simulator : IEnumerable
        {
            string [] moves = {"5", "3", "1","6"};

        
#region IEnumerable Members

public IEnumerator  GetEnumerator()
{
 	foreach(string s in moves)
        yield return s;
}

#endregion
}

    }
}
