using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threading
{
    public class ThreadSafety
    {
        private bool _done;
        private readonly object _lock = new object();
        public void Start()
        {
            Thread t = new Thread(Go);
            t.Start();
            Go();
           // t.Join();
        }
        void Go()
        {
            Monitor.Enter(_lock);
                if (!_done)
                {
                    Console.WriteLine("done");
                    _done = true;
                }

            Monitor.Exit(_lock);
            
        }

        public void LoopExample()
        {
            for(int i = 0; i < 5; i += 1)
            {
                var j = i;
                Thread t = new Thread(() => Console.Write(j));
                //Thread t = new Thread(() => Console.Write(i));
                t.Start();
                //t.Join();
            }
        }
    }
}
