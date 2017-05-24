using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPOQueue.Queue;

namespace PPOQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new PQueue<int>();

            int qSize = 5,
                maxRndValue = 50;
            
            Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

            for (int i = 0; i < qSize; ++i)
                q.Enqueue(rand.Next(maxRndValue));

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                foreach (var value in q.ToList())
                    Console.Write("{0}\t", value);
                Console.WriteLine("\nRangeList = [{0}, {1}]\n\n", q.Minimum(), q.Maximum());

                q.Dequeue();
                q.Enqueue(rand.Next(maxRndValue));
            }
        }
    }
}
