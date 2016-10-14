using Ascentn.AgilePoint.WCFClient;
using Ascentn.Workflow.Base;
using System.Collections;
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
            var properties = ReflectionManager.Singleton.GetGetProperties(source);
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

    public class ReflectionManager
    {
        public static ReflectionManager Singleton { get; private set; }

        static ReflectionManager()
        {
            Singleton = new ReflectionManager();
        }

        private ReflectionManager()
        {
        }

        private Hashtable _cache = new Hashtable();

        public PropertyInfo[] GetGetProperties(object obj)
        {
            var type = obj.GetType();
            var key = type.FullName;
            if (_cache.ContainsKey(key))
            {
                return _cache[key] as PropertyInfo[];
            }
            else
            {
                var properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public);
                if (!_cache.ContainsKey(key)) _cache.Add(key, properties);
                return properties;
            }
        }
    }
}
