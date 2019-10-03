using System;
using System.Threading;
using Threading;

namespace Oct19.Study
{
    class Program
    {

        static void Main(string[] args)
        {
            // TestBasicThreading();
            //TestThreadSafety();
            TestThreadSignalling();
            Console.Read();
        }

        static void TestBasicThreading()
        {
            BasicStuff t = new BasicStuff();
            t.BasicThreading();
            t.JoinThread();
            //t.SharedState();

        }

        static void TestThreadSafety()
        {
            ThreadSafety ts = new ThreadSafety();
            //ts.Start();
            //ts.LoopExample();
            ts.Deadlock();
        }

        static void TestThreadSignalling()
        {
            Signalling nl = new Signalling();
            //for (int i = 0; i < 255; i++)
            //{
            //    Thread.Sleep(5);
            //    nl.NoLock();
            //}

            //nl.Semaphores();
            nl.WaitingForThreadpool();

        }
    }
}
