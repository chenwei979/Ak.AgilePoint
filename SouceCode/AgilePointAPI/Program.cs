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
            //var manager = new WorkflowInstanceManager("apdomain\\administrator");
            //manager.Create("Lev", new { LeaveDays = 21 });

            var manager = new WorkflowTaskManager("apdomain\\administrator");
            var items = manager.GetMyTask();
            manager.Approve(items.Last().WorkItemID, null);
        }
    }
}
