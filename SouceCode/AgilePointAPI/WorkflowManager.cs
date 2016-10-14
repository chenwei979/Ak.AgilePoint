using Ascentn.AgilePoint.WCFClient;
using Ascentn.Workflow.Base;
using System.Collections.Generic;
using System.Reflection;

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

        public IEnumerable<NameValue> GenerateAtrributes(object source)
        {
            var properties = source.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (var property in properties)
            {
                var propertyName = GetPropertyName(property.Name);
                yield return new NameValue(propertyName, property.GetValue(source, null));
            }
        }

        public string GetPropertyName(string name, string prefix = "/pd:AP/pd:processFields/pd:")
        {
            return string.Concat(prefix, name);
        }
    }
}
