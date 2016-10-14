using Ascentn.AgilePoint.WCFClient;

namespace AgilePointAPI
{
    public abstract class WorkflowManager
    {
        public string UserAccount { get; private set; }
        public WCFWorkflowProxy WorkflowService { get; private set; }

        public WorkflowManager(string userAccount)
        {
            UserAccount = userAccount;
            WorkflowService = WorkflowServiceFactory.CreateWorkflowService(userAccount);
        }
    }
}
