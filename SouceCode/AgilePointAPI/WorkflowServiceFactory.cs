using Ascentn.AgilePoint.WCFClient;
using System;
using System.Configuration;
using System.Net;

namespace AgilePointAPI
{
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
