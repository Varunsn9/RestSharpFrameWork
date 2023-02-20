using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpFrameWork.generic;
using RestSharpFrameWork.PocoClassRmgYantra.EmployeeController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameWork.RmgYantraTest
{/// <summary>
/// TestMethods for testing
/// </summary>

    public class EmployeePost : BaseClass
    {
        [TestMethod]
        [TestCategory("Practice")]
        public void EmployeesPost()
        {
            string url = ("http://localhost:8084/");
            IRestClient client=new RestClient(url);
            IRestRequest request=new RestRequest(endPoints.addProject, Method.POST);
            Project project = new Project
            {
                createdBy = "varunsn",
                projectName = "Test",
                status = "open",
                teamSize = 0 
            }; 
            request.AddJsonBody(project);
            var response=client.Execute(request);
            Console.WriteLine(response.IsSuccessful);
        }
        
        [TestMethod]
        [TestCategory("Practice")]
        public void GetEmp()
        {
            string url = "http://localhost:8084/employees";
            IRestClient client = new RestClient(url);
            IRestRequest request= new RestRequest(Method.GET);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
