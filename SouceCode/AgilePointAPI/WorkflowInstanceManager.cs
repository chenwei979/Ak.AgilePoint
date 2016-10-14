using Ascentn.Workflow.Base;
using System;

namespace AgilePointAPI
{
    public class WorkflowInstanceManager : WorkflowManager
    {
        public WorkflowInstanceManager(string userAccount) : base(userAccount)
        {
        }

        //<summary>
        // 创建流程实例
        // defName 流程定义
        // proInstName 表单名称
        // atrributes 表单相关字段
        //submiter 提交人 apdomain\\administrator 必须是域账户
        //</summary>
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

        // <summary>
        // 取消流程实例
        ///// </summary>
        public void Cancel()
        {

        }

        private string GenerateInstanceTitle(string workflowName)
        {
            return workflowName + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
