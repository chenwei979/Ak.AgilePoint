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
            /* Instance */
            //var manager = new WorkflowInstanceManager("apdomain\\administrator");
            //var applications = manager.GetMyApplication();
            //var applications2 = manager.GetPagedMyPenddingApplication(4, 8);
            //manager.Create("Lev", new
            //{
            //    LeaveDays = 6
            //});


            /* Task */
            //var taskManager = new WorkflowTaskManager("apdomain\\administrator");
            //var items = taskManager.GetMyTask();
            //taskManager.Approve(items.Last().WorkItemID, new {
            //    DepartmentManagerAccount = "apdomain\\alice",
            //});

            //var taskManager2 = new WorkflowTaskManager("apdomain\\alice");
            //var items2 = taskManager2.GetMyTask();
            //taskManager2.Reject(items2.Last().WorkItemID, null);


            /* Delegation */
            var delegateManager = new WorkflowDelegationManager("apdomain\\administrator");

            var delegationId = string.Empty;
            delegateManager.AddDelegation(new WorkflowDelegation()
            {
                Enable = true,
                StartDate = new DateTime(2016, 10, 1),
                EndDate = new DateTime(2016, 10, 11),
                Description = "Bruce Test Delegation",
                FromUser = "apdomain\\administrator",
                ToUser = "apdomain\\alice",
            }, out delegationId);
        }
    }
}
