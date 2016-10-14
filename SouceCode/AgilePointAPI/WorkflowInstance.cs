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
    public class Constant
    {
        public const string AppName = "Test";
        public const string DomainName = "apdomain";
        public const string AdministratorAccount = "Administrator";
        public const string AdministratorPassword = "pass";
    }

    public class WorkflowServiceFactory
    {
        public static WCFWorkflowProxy CreateWorkflowService(string initiator)
        {
            var appName = Constant.AppName;
            var credential = new NetworkCredential(Constant.AdministratorAccount, Constant.AdministratorPassword, Constant.DomainName);
            var workFlowServiceBindingName = Convert.ToString(ConfigurationManager.AppSettings["WorkFlowBindingUsed"]);
            return new WCFWorkflowProxy(appName, string.Empty, "en-US", initiator, credential, workFlowServiceBindingName);
        }
    }

    

    

    
}
