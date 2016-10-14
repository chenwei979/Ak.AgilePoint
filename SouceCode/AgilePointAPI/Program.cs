using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ascentn.Workflow.Base;
using System.Configuration;
using Ascentn.AgilePoint.WCFClient;

namespace AgilePointAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInstanceManager instance = new WorkflowInstanceManager("apdomain\\administrator");

            //参数
            //直线领导
            var pars = new List<NameValue>();
            pars.Add(new NameValue("/pd:AP/pd:processFields/pd:Day", 2));
            instance.Create("Lev", pars.ToArray());
        }

        //public string GetBaseProcDefID()
        //{
        //    //string URI = "https://mydomain:9011/AgilePointServer/Workflow/GetBaseProcDefID/Test2";
        //    //HTTPOperations ops = new HTTPOperations("apdomain", "administrator",
        //    //                     "pass", appID, locale);
        //    //return ops.GetData(URI);
        //}
    }
}
