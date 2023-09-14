using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpFrameWork.generic;
using RestSharpFrameWork.PocoClassRmgYantra.EmployeeController;
using SpecFlow.Internal.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestSharpFrameWork.RmgYantraTest
{/// <summary>
/// TestMethods for testing
/// </summary>
    [TestClass]
    public class EmployeePost //: BaseClass
    {
        [TestMethod]
        [TestCategory("Practice")]
        public void ProjectPost()
        {
            string url = ("http://localhost:8084/");
            IRestClient client=new RestClient(url);
            IEndPoints endPoints = new EndPoints();
            IRestRequest request=new RestRequest(endPoints.addProject, Method.POST);
            Project project = new Project
            {
                createdBy = "datta",
                projectName = "Tesst",
                status = "open",
                teamSize = 0 
            }; 
            request.AddJsonBody(project);
            var response=client.Execute(request);
           // Console.WriteLine((int)(response.));
        }
        [TestMethod]
        [TestCategory("Practice")]
        public void PostEmployee()
        {
            string url = ("http://localhost:8084/");
            IRestClient client = new RestClient(url);
            IEndPoints endPoints = new EndPoints();
            IRestRequest request = new RestRequest(endPoints.addProject,Method.POST);
            Project project = new Project
            {
                createdBy = "dtta",
                projectName = "wTst",
                status = "open",
                teamSize = 0
            };
            request.AddJsonBody(project);
            var response = client.Execute(request);
            Console.WriteLine(response.Headers);
            Console.WriteLine(response.Content);
            var body = response.Content.Contains("status");
            Console.WriteLine(body);
            Console.WriteLine(((int)response.StatusCode));
        }

        [TestMethod]
        [TestCategory("Practice")]
        public void GetEmp()
        {
            string url = "http://localhost:8084/employees";
            IEndPoints endPoints= new EndPoints();
            
            IRestClient client = new RestClient(url);
            IRestRequest request= new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var headers=response.Headers;
            foreach(var header in headers)
            {
                Console.WriteLine($"{header.Name} = {header.Value}");
            }
            var cookies=response.Cookies;
            Console.WriteLine("==================================");
            foreach (var cookie in cookies)
            {
                Console.WriteLine($"{cookie.Name} = {cookie.Value}");
            }
            Console.WriteLine(cookies);
            Console.WriteLine("==================================");
            var body = response.Content;
            Console.WriteLine(body);
            Console.WriteLine(body.Contains("TYP_00212"));
        }
    }
}
