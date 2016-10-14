using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ascentn.Workflow.Base;
using System.Configuration;
using Ascentn.AgilePoint.WCFClient;


namespace AgilePointAPI
{
    public class Task
    {
        /// <summary>
        /// 审批任务（审批通过，拒绝）
        ///  //<summary>
        // 创建流程实例
        // defName 流程定义
        // proInstName 表单名称
        // atrributes 表单相关字段
        //submiter 提交人 apdomain\\administrator 必须是域账户
        /// </summary>
        public void Approve(string defName, string proInstName, string submiter, NameValue[] atrributes)
        {
            System.Net.ICredentials credentials = new System.Net.NetworkCredential("Administrator",
                "pass",
                "apdomain");
            string workFlowBinding = (String)ConfigurationManager.AppSettings["WorkFlowBindingUsed"];
            IWFWorkflowService workflowService = new WCFWorkflowProxy("Leave", "", "en-US", submiter, credentials, workFlowBinding);

           // WFManualWorkItem WorkItem = workflowService.GetWorkItem(Request.QueryString["WID"]);
        }

        /// <summary>
        /// 输入值为域名账户
        /// </summary>
        /// <param name="assignTo"></param>
        public void GetMyTask(string assignTo)
        {
            /*
             SELECT
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
AND WF_PROC_INSTS.status = 'Running'



             */

        }

    }
}
