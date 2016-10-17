using Ascentn.Workflow.Base;
using System;

namespace AgilePointAPI
{
    public class WorkflowInstanceManager : WorkflowManager
    {
        public WorkflowInstanceManager(string userAccount) : base(userAccount)
        {
        }

        public void Create(string workflowName, object source)
        {
            var pid = WorkflowService.GetReleasedPID(workflowName);
            var piid = UUID.GetID();
            var workobjectid = UUID.GetID();
            var instanceTitle = GenerateInstanceTitle(workflowName);
            var atrributes = GenerateAtrributes(source);
            var evt = WorkflowService.CreateProcInstEx(pid, piid, instanceTitle, workobjectid, string.Empty, string.Empty, atrributes, true);
            while (evt.Status == WFEvent.SENT)
            {
                System.Threading.Thread.Sleep(1000);
                evt = WorkflowService.GetEvent(evt.EventID);
            }
        }

        public void Cancel(string PIID)
        {
            var evt = WorkflowService.CancelProcInst(PIID);
            while (evt.Status == WFEvent.SENT)
            {
                System.Threading.Thread.Sleep(1000);
                evt = WorkflowService.GetEvent(evt.EventID);
            }
        }

        public WFBaseProcessInstance[] GetMyApplication()
        {
            string status = WFProcessInstance.RUNNING;
            WFAny any = WFAny.Create(status);
            WFQueryExpr query = new WFQueryExpr("STATUS", SQLExpr.EQ, any, true);
            return WorkflowService.QueryProcInsts(query);
        }

        public WFBaseProcessInstance[] GetPagedMyApplication(int pageIndex, int pageSize)
        {
            string where = string.Format("[STATUS] = 'Completed' ORDER BY [STARTED_DATE] OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY;", (pageIndex - 1) * pageSize, pageSize);
            WorkflowService.QueryProcInstsEx(where);
        }

        private string GenerateInstanceTitle(string workflowName)
        {
            return workflowName + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
