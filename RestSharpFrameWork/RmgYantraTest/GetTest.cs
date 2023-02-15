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
    [TestClass]
    public class GetTest : BaseClass
    {
        [TestMethod]
        
        [TestCategory("GET")]
        public void GetEmployeesTest()
        {
            RestSharpUtils rsu= new RestSharpUtils();
            
            var response=rsu.Get(EndPoints.employees);
            Console.WriteLine(response.IsSuccessful); 
            var cookies=response.Cookies;
        }
        [TestMethod]
        [TestCategory("GET")]
        public void GetEmployeeTest()
        {
            RestSharpUtils rsu = new RestSharpUtils();

            var response = rsu.Get(EndPoints.employeesId, "TYP_00410");
            Console.WriteLine(response.IsSuccessful);
            Validation val=new Validation();
            val.CookiesValidation(response);
            val.HeaderValidation(response, "Vary");

        }

        [TestMethod]
        [TestCategory("GET")]
        public void validateEmployee()
        {
            RestSharpUtils rsu = new RestSharpUtils();
            var response = rsu.Get(EndPoints.employees, "TYP_00410");
            Console.WriteLine(response.IsSuccessful);
            Validation val=new Validation();
            var req=response.Content;
            bool value=val.JSONBodyValidation(response, "project");
            Console.WriteLine(value);
        }
    }
}
