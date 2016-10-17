using Ascentn.AgilePoint.WCFClient.AdminService;
using Ascentn.Workflow.Base;
using System;

namespace AgilePointAPI
{
    public class WorkflowDelegateManager : WorkflowManager
    {
        public Lazy<IWCFAdminService> AdminService = new Lazy<IWCFAdminService>(() =>
        {
            return WorkflowServiceFactory.CreateAdminService();
        });

        public WorkflowDelegateManager(string userAccount) : base(userAccount)
        {
        }

        public WFBaseProcessInstance[] GetItems()
        {
            string status = WFProcessInstance.RUNNING;
            WFAny any = WFAny.Create(status);
            WFQueryExpr query = new WFQueryExpr("STATUS", SQLExpr.EQ, any, true);
            return WorkflowService.QueryProcInsts(query);
        }
    }
}
