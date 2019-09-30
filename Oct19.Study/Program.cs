using System;
using Threading;

namespace Oct19.Study
{
    class Program
    { 

        static void Main(string[] args)
        {
            // TestBasicThreading();
            TestThreadSafety();
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
            ts.LoopExample();
        }
    }
}
