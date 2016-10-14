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

    public class WorkflowInstance
    {
        //<summary>
        // 创建流程实例
        // defName 流程定义
        // proInstName 表单名称
        // atrributes 表单相关字段
        //submiter 提交人 apdomain\\administrator 必须是域账户
        //</summary>
        public void Create(string workflowName, string initiator, NameValue[] atrributes)
        {
            var workflowService = WCFWorkflowProxyFactory.CreateWorkflowService(initiator);
            var pid = workflowService.GetReleasedPID(workflowName);
            var piid = UUID.GetID();
            var workobjectid = UUID.GetID();
            var evt = workflowService.CreateProcInstEx(pid, piid, workflowName + DateTime.Now.ToString("yyyyMMddHHmmss"), workobjectid, "", "", atrributes, true);
            while (evt.Status == WFEvent.SENT)
            {
                System.Threading.Thread.Sleep(1000);
                evt = workflowService.GetEvent(evt.EventID);
            }
            Approve("", null);
        }

        // <summary>
        // 取消流程实例
        ///// </summary>
        public void Cancel()
        {

        }

        public void Approve(string initiator, NameValue[] atrributes)
        {
            foreach (var task in workitems)
            {
                workflowService.SetCustomAttr(task.WorkObjectID, "/pd:AP/pd:processFields/pd:Approve", "true");
                WFEvent evt = workflowService.CompleteWorkItem(task.WorkItemID);
                while (evt.Status == WFEvent.SENT)
                {
                    System.Threading.Thread.Sleep(1000);
                    evt = workflowService.GetEvent(evt.EventID);
                }
            }
        }
    }

    public class WorkflowTask
    {
        public IList<WFManualWorkItem> GetMyTask(string account)
        {
            var workflowService = WCFWorkflowProxyFactory.CreateWorkflowService(account);
            var status = string.Join(";", WFManualWorkItem.ASSIGNED, WFManualWorkItem.NEW, WFManualWorkItem.OVERDUE);
            return workflowService.GetWorkListByUserID(account, status);
        }
    }
}
