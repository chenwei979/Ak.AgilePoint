using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowflak
{
    class Program
    {
        static void Main(string[] args)
        {
            IdWorker worker = new IdWorker(12L);
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine(worker.NextId());
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
