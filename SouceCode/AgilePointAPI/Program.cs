﻿using System;
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
            var manager = new WorkflowInstanceManager("apdomain\\administrator");
            var applications = manager.MyApplication();

            //manager.Create("Lev", new
            //{
            //    LeaveDays = 6
            //});

            //var taskManager = new WorkflowTaskManager("apdomain\\administrator");
            //var items = taskManager.GetMyTask();
            //taskManager.Approve(items.Last().WorkItemID, new {
            //    DepartmentManagerAccount = "apdomain\\alice",
            //});

            //var taskManager2 = new WorkflowTaskManager("apdomain\\alice");
            //var items2 = taskManager2.GetMyTask();
            //taskManager2.Reject(items2.Last().WorkItemID, null);
        }
    }
}
