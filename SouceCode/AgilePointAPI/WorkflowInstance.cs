﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ascentn.Workflow.Base;
using System.Configuration;
using Ascentn.AgilePoint.WCFClient;
using System.Net;

namespace AgilePointAPI
{
    public class WorkflowInstance
    {

        public WCFWorkflowProxy workflowService = null;
        //<summary>
        // 创建流程实例
        // defName 流程定义
        // proInstName 表单名称
        // atrributes 表单相关字段
        //submiter 提交人 apdomain\\administrator 必须是域账户
        //</summary>
        public void Create(string appName, string workflowName, string initiator, NameValue[] atrributes)
        {
            var credential = new NetworkCredential("Administrator", "pass", "apdomain");
            var workFlowServiceBindingName = Convert.ToString(ConfigurationManager.AppSettings["WorkFlowBindingUsed"]);

            workflowService = new WCFWorkflowProxy(appName, "", "en-US", initiator, credential, workFlowServiceBindingName);
            string pid = workflowService.GetReleasedPID(workflowName);
            string piid = UUID.GetID();
            string workobjectid = UUID.GetID();
            WFEvent evt = workflowService.CreateProcInstEx(pid, piid, workflowName + DateTime.Now.ToString("yyyyMMddHHmmss"), workobjectid, "", "", atrributes, true);
            while (evt.Status == WFEvent.SENT)
            {
                System.Threading.Thread.Sleep(1000);
                evt = workflowService.GetEvent(evt.EventID);
            }
            Approve("", "", "", null);
        }

        // <summary>
        // 取消流程实例
        ///// </summary>
        public void Cancel()
        {

        }

        public void Approve(string appName, string workflowName, string initiator, NameValue[] atrributes)
        {
            //代办
            string Status = string.Format("{0};{1};{2}",
WFManualWorkItem.ASSIGNED, WFManualWorkItem.OVERDUE, WFManualWorkItem.NEW);
           
            var workitems = workflowService.GetWorkListByUserID("APDOMAIN\\Administrator", Status);

            foreach (var task in workitems)
            {
                workflowService.SetCustomAttr(task.WorkObjectID, "/pd:AP/pd:processFields/pd:Approve", "true");
                WFEvent evt  = workflowService.CompleteWorkItem(task.WorkItemID);
                while (evt.Status == WFEvent.SENT)
                {
                    System.Threading.Thread.Sleep(1000);
                    evt = workflowService.GetEvent(evt.EventID);
                }
            }
        }
    }
}
