using Ascentn.Workflow.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilePointAPI
{
    public class WorkflowDelegateManager : WorkflowManager
    {
        public WorkflowDelegateManager(string userAccount) : base(userAccount)
        {
        }

        public IList<WorkflowDelegation> GetDelegations(string from)
        {
            return AdminService.GetDelegations(null, from, string.Empty, string.Empty).Select(item =>
            {
                WorkflowDelegation delegation = item;
                return delegation;
            }).ToList();
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

        public void DeleteDelegation(string delegationId)
        {
            AdminService.RemoveDelegation(null, delegationId);
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

        public static implicit operator WorkflowDelegation(WFDelegation delegation)
        {
            return new WorkflowDelegation()
            {
                CreatedBy = delegation.CreatedBy,
                CreatedDate = delegation.CreatedDate,
                CancelledBy = delegation.CancelledBy,
                CancelledDate = delegation.CancelledDate,
                LastUpdatedBy = delegation.LastUpdatedBy,
                LastUpdatedDate = delegation.LastUpdatedDate,

                DelegationID = delegation.DelegationID,
                Status = delegation.Status,
                RecWeekdaysString = delegation.RecWeekdaysString,

                ProcDefIDS = delegation.ProcDefIDS,
                FromUser = delegation.FromUser,
                ToUser = delegation.ToUser,
                StartDate = delegation.StartDate,
                EndDate = delegation.EndDate,
                Description = delegation.Description
            };
        }
    }
}
