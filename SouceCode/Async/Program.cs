using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }


        public void hello()
        {
            string s = await methodAsync();

        }
        private Task<string> methodAsync()
        {
            Thread.Sleep(10000);
          return "Hello"; //Error: Cannot implicitly convert type 'string' to 'System.Threading.Tasks.Task<string>'
        }
    }
}
