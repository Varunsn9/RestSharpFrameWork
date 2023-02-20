using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RestSharp;
using RestSharpFrameWork.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RestSharpFrameWork.RmgYantraTest
{
    
    public class GetTest : BaseClass
    {
        [TestMethod]

        [TestCategory("Practice")]
        public void GetEmployeesTest()
        {
            RestSharpUtils rsu= new RestSharpUtils();
            
            var response=rsu.Get(endPoints.employees);
            Console.WriteLine(response.IsSuccessful); 
            var cookies=response.Cookies;
        }

        [TestMethod]
        [TestCategory("Practice")]
        public void GetEmployeeTest()
        {
            RestSharpUtils rsu = new RestSharpUtils();

            var response = rsu.Get(endPoints.employeesId, "TYP_00410");
            Console.WriteLine(response.IsSuccessful);
            rsu.validationCookies(response);
            rsu.validationHeader(response, "Vary");

        }

        [TestMethod]
        [TestCategory("Practice")]
        public void validateEmployee()
        {
            RestSharpUtils rsu = new RestSharpUtils();
            var response = rsu.Get(endPoints.employees, "TYP_00410");
            Console.WriteLine(response.IsSuccessful);
           
            var req=response.Content;
            bool value= rsu.validationJSONBody(response, "project");
            Console.WriteLine(value);
        }
    }
}
