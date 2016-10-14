using Ascentn.Workflow.Base;
using System;

namespace AgilePointAPI
{
    public class WorkflowInstanceManager : WorkflowManager
    {
        public WorkflowInstanceManager(string userAccount) : base(userAccount)
        {
        }

        public void Create(string workflowName, NameValue[] atrributes)
        {
            var pid = WorkflowService.GetReleasedPID(workflowName);
            var piid = UUID.GetID();
            var workobjectid = UUID.GetID();
            var instanceTitle = GenerateInstanceTitle(workflowName);
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

        private string GenerateInstanceTitle(string workflowName)
        {
            return workflowName + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
