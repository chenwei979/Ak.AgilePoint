using Ascentn.AgilePoint.WCFClient.AdminService;
using Ascentn.Workflow.Base;
using System;

namespace AgilePointAPI
{
    public class WorkflowDelegateManager : WorkflowManager
    {
        

        public WorkflowDelegateManager(string userAccount) : base(userAccount)
        {
        }

        public WFBaseProcessInstance[] GetItems()
        {
            //AdminService.Value.AddDelegation();
            //return WorkflowService.QueryProcInsts(query);
            return null;
        }
    }
}
