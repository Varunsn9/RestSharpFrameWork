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
{
    [TestClass]
    public class EmployeePost 
    {
        [TestMethod]
        [TestCategory("Employee")]
        public void EmployeesPost()
        {
            string url = ("http://localhost:8084/");
            IRestClient client=new RestClient(url);
            IRestRequest request=new RestRequest(EndPoints.addProject, Method.POST);
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
        
        [TestMethod,TestCategory("GET")]
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
