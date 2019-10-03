using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threading
{
    public class Signalling
    {
        public void NoLock()
        {
            ManualResetEvent signal = new ManualResetEvent(false);
    
            var x = 0;
            new Thread(_ =>
            {
                x += 1;
                signal.Set();
            }).Start();
            signal.WaitOne();
            Console.Write(x);
        }

        private Semaphore _sema = new Semaphore(3, 3);
        public void Semaphores()
        {
            for (int i = 0; i < 7; i++)
            {
                var j = i;
                new Thread(_ => EnterClub(j)).Start();
            }
        }

        private void EnterClub(int i) {
            Console.WriteLine("{0} trying to enter club", i);
            _sema.WaitOne();
            Console.WriteLine("{0} entered club", i);
            Thread.Sleep(1000 * i);
            Console.WriteLine("{0} leaving club", i);
            _sema.Release();
      
        }
        
        public void WaitingForThreadpool()
        {
            ManualResetEvent signal = new ManualResetEvent(false);
            int runs = 10;
            for (int i = 0; i < runs; i++)
            {
                ThreadPool.QueueUserWorkItem(j => {
                    //int j = (int)i;
                    Console.WriteLine("working on {0}", j);
                    if (Interlocked.Decrement(ref runs) == 0)
                    {
                        signal.Set();
                    }
                }, i );
            }
            signal.WaitOne();
            Console.WriteLine("Done WaitingForThreadpool");
        }

        //void DoWork(object arg)
        //{
        //    int i = (int)arg;
        //    Console.WriteLine("working on {0}",i);
        //    if (Interlocked.Decrement(ref runs) == 0)
        //    {
        //        signal.Set();
        //    }
        //}
    }
}
