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

            /* SELECT
	            WF_MANUAL_WORKITEMS.WORK_ITEM_ID,
	            WF_MANUAL_WORKITEMS.NAME,
	            WF_MANUAL_WORKITEMS.LAST_MODIFIED_BY,
	            WF_MANUAL_WORKITEMS.ASSIGNED_DATE,
	            WF_MANUAL_WORKITEMS.LAST_MODIFIED_DATE,
	            WF_MANUAL_WORKITEMS.CANCELLED_DATE,
	            WF_MANUAL_WORKITEMS.COMPLETED_DATE,
	            WF_MANUAL_WORKITEMS.DUE_DATE,
	            WF_MANUAL_WORKITEMS.CREATED_DATE,
	            WF_MANUAL_WORKITEMS.SOURCE_WORK_ITEM_ID,
	            WF_MANUAL_WORKITEMS.DUE_HANDLED,
	            WF_MANUAL_WORKITEMS.WAIT_WORKPERFORMED,
	            WF_MANUAL_WORKITEMS.PROC_DEF_ID,
	            WF_MANUAL_WORKITEMS.ACTIVITY_INST_ID,
	            WF_MANUAL_WORKITEMS.STATUS,
	            WF_MANUAL_WORKITEMS.USER_ID,
	            WF_MANUAL_WORKITEMS.WORK_OBJECT_ID,
	            WF_MANUAL_WORKITEMS.PENDING,
	            WF_MANUAL_WORKITEMS.APPL_NAME,
	            WF_MANUAL_WORKITEMS.BEING_PROCESSED,
	            WF_MANUAL_WORKITEMS.SESSION_,
	            WF_MANUAL_WORKITEMS.POOL_ID,
	            WF_MANUAL_WORKITEMS.ORIGINAL_USER_ID,
	            WF_MANUAL_WORKITEMS.CLIENT_DATA,
	            WF_MANUAL_WORKITEMS.POOL_INFO,
	            WF_MANUAL_WORKITEMS.RESTRICTION_TYPE,
	            WF_PROC_DEFS.DEF_NAME,
	            WF_PROC_INSTS.DEF_ID,
	            WF_ACTIVITY_INSTS.DISPLAY_NAME,
	            WF_PROC_INSTS.PROC_INST_NAME,
	            WF_MANUAL_WORKITEMS.PROC_INST_ID,
	            WF_PROC_INSTS.STARTED_DATE,
	            WF_PROC_INSTS.STATUS PSTATUS,
	            WF_PROC_INSTS.PROC_INITIATOR
            FROM
	            WF_PROC_INSTS,
	            WF_MANUAL_WORKITEMS,
	            WF_PROC_DEFS,
	            WF_ACTIVITY_INSTS
            WHERE
	            WF_MANUAL_WORKITEMS.PROC_INST_ID = WF_PROC_INSTS.PROC_INST_ID
            AND WF_PROC_INSTS.DEF_ID = WF_PROC_DEFS.DEF_ID
            AND WF_MANUAL_WORKITEMS.ACTIVITY_INST_ID = WF_ACTIVITY_INSTS.ID
            AND WF_MANUAL_WORKITEMS.BEING_PROCESSED = 'No'
            AND WF_MANUAL_WORKITEMS.user_id = N'apdomain\Administrator'
            AND WF_MANUAL_WORKITEMS.status IN (
	            'Assigned',
	            'Overdue',
	            'Carbon',
	            'New'
            )
            AND WF_PROC_INSTS.status = 'Running'*/
        }

        public WFManualWorkItem GetTaskById(string workItemId)
        {
            return WorkflowService.GetWorkItem(workItemId);
        }

        public void Approve(string workItemId, object source)
        {
            var atrributes = GenerateAtrributes(source);
            Complete(workItemId, true, atrributes);
        }

        public void Reject(string workItemId, object source)
        {
            var atrributes = GenerateAtrributes(source);
            Complete(workItemId, false, atrributes);
        }

        private void Complete(string workItemId, bool approval, NameValue[] atrributes)
        {
            var task = GetTaskById(workItemId);
            var atrributeName = GetPropertyName(string.Format("{0}ApproveResult", task.DisplayName));
            WorkflowService.SetCustomAttr(task.WorkObjectID, atrributeName, approval);
            WorkflowService.SetCustomAttrs(task.WorkObjectID, atrributes);
            var evt = WorkflowService.CompleteWorkItem(task.WorkItemID);
            while (evt.Status == WFEvent.SENT)
            {
                System.Threading.Thread.Sleep(1000);
                evt = WorkflowService.GetEvent(evt.EventID);
            }
        }
    }
}
