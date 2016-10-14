using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ascentn.Workflow.Base;
using System.Configuration;
using Ascentn.AgilePoint.WCFClient;
using System.Net;

namespace AgilePointAPI
{
    public class Constant
    {
        public const string AppName = "Test";
        public const string DomainName = "apdomain";
        public const string AdministratorAccount = "Administrator";
        public const string AdministratorPassword = "pass";
    }

    public class WCFWorkflowProxyFactory
    {
        public static WCFWorkflowProxy CreateWorkflowService(string initiator)
        {
            var appName = Constant.AppName;
            var credential = new NetworkCredential(Constant.AdministratorAccount, Constant.AdministratorPassword, Constant.DomainName);
            var workFlowServiceBindingName = Convert.ToString(ConfigurationManager.AppSettings["WorkFlowBindingUsed"]);
            return new WCFWorkflowProxy(appName, string.Empty, "en-US", initiator, credential, workFlowServiceBindingName);
        }
    }

    public class WorkflowInstanceManager
    {
        public string UserAccount { get; private set; }
        public WCFWorkflowProxy WorkflowService { get; private set; }

        public WorkflowInstanceManager(string userAccount)
        {
            UserAccount = userAccount;
            WorkflowService = WCFWorkflowProxyFactory.CreateWorkflowService(userAccount);
        }

        //<summary>
        // 创建流程实例
        // defName 流程定义
        // proInstName 表单名称
        // atrributes 表单相关字段
        //submiter 提交人 apdomain\\administrator 必须是域账户
        //</summary>
        public void Create(string workflowName, string initiator, NameValue[] atrributes)
        {
            var pid = WorkflowService.GetReleasedPID(workflowName);
            var piid = UUID.GetID();
            var workobjectid = UUID.GetID();
            var evt = WorkflowService.CreateProcInstEx(pid, piid, workflowName + DateTime.Now.ToString("yyyyMMddHHmmss"), workobjectid, "", "", atrributes, true);
            while (evt.Status == WFEvent.SENT)
            {
                System.Threading.Thread.Sleep(1000);
                evt = WorkflowService.GetEvent(evt.EventID);
            }
        }

        // <summary>
        // 取消流程实例
        ///// </summary>
        public void Cancel()
        {

        }
    }

    public class WorkflowTaskManager
    {
        public string UserAccount { get; private set; }
        public WCFWorkflowProxy WorkflowService { get; private set; }

        public WorkflowTaskManager(string userAccount)
        {
            UserAccount = userAccount;
            WorkflowService = WCFWorkflowProxyFactory.CreateWorkflowService(userAccount);
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
            WorkflowService.SetCustomAttr(task.WorkObjectID, "/pd:AP/pd:processFields/pd:Approve", "true");
            var evt = WorkflowService.CompleteWorkItem(task.WorkItemID);
            while (evt.Status == WFEvent.SENT)
            {
                System.Threading.Thread.Sleep(1000);
                evt = WorkflowService.GetEvent(evt.EventID);
            }
        }
    }
}
