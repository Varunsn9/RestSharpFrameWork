using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameWork.PocoClassRmgYantra.EmployeeController
{
    /// <summary>
    /// Simple Test method
    /// </summary>
  
    public class GetEmpoloyeeByUserName
    {
        Employee employee;
 
        [TestMethod]
        [TestCategory("Practice")]
        public void Get() 
        {
            string url = "http://localhost:3000";
            var client=new RestClient(url);
            var request = new RestRequest("/comments",Method.POST) ;
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
            employee = new Employee { empName="yousuf",
            email="yousuf@gmail.com",designation="TestLead"};
            request.AddJsonBody(employee);
            var res=client.Execute(request);
            Console.WriteLine(res.Content);
        }
    }
}
