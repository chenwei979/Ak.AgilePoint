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

        public bool AddDelegation(WorkflowDelegation delegation, out string delegationId)
        {
            var delegationObj = AdminService.AddDelegation(null, new WFDelegation()
            {
                ProcDefIDS = delegation.ProcDefIDS,
                FromUser = delegation.FromUser,
                ToUser = delegation.ToUser,
                StartDate = delegation.StartDate,
                EndDate = delegation.EndDate,
                Description = delegation.Description
            });

            if (delegationObj == null) throw new Exception("delegationObj is null.");

            delegationId = delegationObj.DelegationID;
            return delegation.Enable ? delegationObj.Active() : true;
        }
    }

    public class WorkflowDelegation
    {
        public string CreatedBy { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string LastUpdatedBy { get; private set; }
        public DateTime LastUpdatedDate { get; private set; }
        public string CancelledBy { get; private set; }
        public DateTime CancelledDate { get; private set; }


        public string DelegationID { get; private set; }
        public string Status { get; private set; }
        public string RecWeekdaysString { get; private set; }

        public string ProcDefIDS { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public bool Enable { get; set; }
    }
}
