using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//* Read in MSDN about the keyword event in C# and how to publish events. Re-implement the above using .NET events and following the best practices.

namespace _08PublishingEvents
{
    //Class which publish an event
    public class Publisher : EventArgs
    {
        //Declare event
        public event EventHandler RaiseCustomEvent;
        //Method that do something and then raise an event
        public void Start(int seconds, int interval)
        {
            int start = 0;
            while (start <= interval)
            {
                Thread.Sleep(start * 1000);
                start += seconds;
                OnRaiseCustomEvent();
            }
        }

        protected virtual void OnRaiseCustomEvent()
        {
            EventHandler e = RaiseCustomEvent;
            if (e != null)
            {
                e(this, null);
            }
        }
    }

    public class Handler
    {
        public Handler(Publisher pub)
        {
            pub.RaiseCustomEvent += HandleCustomEvent;
        }
        //Method that describes what actions to take when the event is raise
        public static void HandleCustomEvent(object sender, EventArgs args)
        {
            Console.WriteLine("Hello!");
        }
    }
    public class Program
    {
        static void Main()
        {
            Publisher pub = new Publisher();
            Handler h = new Handler(pub);
            //Method which raises event
            pub.Start(2, 10);
        }
    }   
}
