using Ascentn.Workflow.Base;

namespace AgilePointAPI
{
    public class WorkflowDelegateManager : WorkflowManager
    {
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
