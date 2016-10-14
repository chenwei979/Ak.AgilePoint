using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ascentn.Workflow.Base;
using System.Configuration;
using Ascentn.AgilePoint.WCFClient;

namespace AgilePointAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInstanceManager instance = new WorkflowInstanceManager("apdomain\\administrator");
            instance.Create("Lev", new { LeaveDays = 21 });
        }
    }
}
