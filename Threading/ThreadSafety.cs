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
            bool lockTaken = false;
            Monitor.Enter(_lock,ref lockTaken);
            try
            {
                if (!_done)
                {
                    Console.WriteLine("done");
                    _done = true;
                }
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(_lock);
                }
            }
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
        private readonly object _lock1 = new object();
        private readonly object _lock2 = new object();

        public void Deadlock()
        {
            new Thread(_ => {
                lock (_lock2)
                {
                    Thread.Sleep(100);
                    lock (_lock1)
                    {
                        
                        Console.WriteLine("out of lock in thread");
                    }
                }
            }).Start();

            lock (_lock1)
            {
                Thread.Sleep(100);
                lock (_lock2)
                {

                    Console.WriteLine("out of lock");
                }
            }

        }

         
    }
}
