using System;
using System.Threading;

namespace Threading
{
    public class BasicStuff
    {
        public void BasicThreading()
        {
            Thread t = new Thread(() => DoWork('x'));
            t.Start();
            DoWork('w');
            t.Join();
        }
        public void JoinThread()
        {
            Thread t = new Thread(() => DoWork('j'));
            t.Start();
            t.Join();
            DoWork('k');
        }

        bool _done = false;
        public void SharedState()
        {
            new Thread(() => Go()).Start();

            Go();
        }

        void Go()
        {
            if (!_done)
            {
                Console.WriteLine("done");
                _done = true;
            }
        }

        private void DoWork(object o, bool addSleep = true)
        {
            char chr = (char)o;// as char;
            for (int i = 0; i < 300; i++)
            {
                if (addSleep && i % 100 == 0)
                {
                    Thread.Sleep(1);
                }
                DisplayMessage(chr);
            }
        }

        void DisplayMessage(char chr)
        {
            Console.Write(chr);
        }
    }
}
