using Ascentn.AgilePoint.WCFClient.AdminService;
using Ascentn.Workflow.Base;
using System;

namespace AgilePointAPI
{
    public class WorkflowDelegateManager : WorkflowManager
    {


        public WorkflowDelegateManager(string userAccount) : base(userAccount)
        {
        }

        public bool AddDelegation()
        {
            AdminService.AddDelegation(null, new WFDelegation()
            {
                StartDate = new DateTime(2016, 10, 1),
                EndDate = new DateTime(2016, 10, 11),
                Description = "Bruce Test Delegation",
                FromUser = "",
                ToUser = "",
                Status = ""
            });
            return true;
        }
    }

    public class WorkflowDelegation
    {
        public string Status { get; set; }
        public string RecWeekdaysString { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string CancelledBy { get; set; }
        public DateTime CancelledDate { get; set; }



        public string ProcDefIDS { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public string DelegationID { get; set; }
    }
}
