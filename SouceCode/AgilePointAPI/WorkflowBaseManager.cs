using Ascentn.Workflow.Base;
using System.Collections;
using System.Reflection;
using System.Linq;
using System;
using Ascentn.AgilePoint.WCFClient.AdminService;

namespace AgilePointAPI
{
    public abstract class WorkflowBaseManager
    {
        private Lazy<IWFWorkflowService> _workflowService;
        private Lazy<IWCFAdminService> _adminService;

        public string UserAccount { get; private set; }
        public IWFWorkflowService WorkflowService
        {
            get
            {
                return _workflowService.Value;
            }
        }
        public IWCFAdminService AdminService
        {
            get
            {
                return _adminService.Value;
            }
        }

        public WorkflowBaseManager(string userAccount)
        {
            UserAccount = userAccount;
            _workflowService = new Lazy<IWFWorkflowService>(() =>
            {
                return WorkflowServiceFactory.CreateWorkflowService(userAccount);
            });
            _adminService = new Lazy<IWCFAdminService>(() =>
            {
                return WorkflowServiceFactory.CreateAdminService();
            });
        }

        public NameValue[] GenerateAtrributes(object source)
        {
            if (source == null) return new NameValue[0];
            var properties = ReflectionManager.Singleton.GetGetProperties(source);

            return properties.Select(property =>
            {
                var propertyName = GetPropertyName(property.Name);
                return new NameValue(propertyName, property.GetValue(source, null));
            }).ToArray();
        }

        public string GetPropertyName(string name, string prefix = "/pd:AP/pd:processFields/pd:")
        {
            return string.Concat(prefix, name);
        }

        public WCFClientInfo GetServiceInfo()
        {
            return new WCFClientInfo()
            {
                Locale = Constant.Locale,
                AppName = Constant.AppName,
                UserName = Constant.AdministratorAccount,
                //UserName = "apdomain\\administrator",
            };
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
                var properties = type.GetProperties();//BindingFlags.DeclaredOnly | BindingFlags.Public
                if (!_cache.ContainsKey(key)) _cache.Add(key, properties);
                return properties;
            }
        }
    }
}
