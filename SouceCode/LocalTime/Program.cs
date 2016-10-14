using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LocalTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime utcTime = regionalSettings.TimeZone.UTCToLocalTime(System.DateTime.no);
        }
    }
}
