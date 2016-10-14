using Ascentn.Workflow.Base;
using System.Collections.Generic;

namespace AgilePointAPI
{
    public class WorkflowTaskManager : WorkflowManager
    {
        public WorkflowTaskManager(string userAccount) : base(userAccount)
        {
        }

        public IList<WFManualWorkItem> GetMyTask()
        {
            var status = string.Join(";", WFManualWorkItem.ASSIGNED, WFManualWorkItem.NEW, WFManualWorkItem.OVERDUE);
            return WorkflowService.GetWorkListByUserID(UserAccount, status);
        }

        public WFManualWorkItem GetTaskById(string workItemId)
        {
            return WorkflowService.GetWorkItem(workItemId);
        }

        public void Approve(string workItemId, NameValue[] atrributes)
        {
            Complete(workItemId, true, atrributes);
        }

        public void Reject(string workItemId, NameValue[] atrributes)
        {
            Complete(workItemId, false, atrributes);
        }

        private void Complete(string workItemId, bool approval, NameValue[] atrributes)
        {
            var task = GetTaskById(workItemId);
            WorkflowService.SetCustomAttr(task.WorkObjectID, string.Format("/pd:AP/pd:processFields/pd:{0}ApproveResult", task.Name), approval);
            var evt = WorkflowService.CompleteWorkItem(task.WorkItemID);
            while (evt.Status == WFEvent.SENT)
            {
                System.Threading.Thread.Sleep(1000);
                evt = WorkflowService.GetEvent(evt.EventID);
            }
        }
    }
}
