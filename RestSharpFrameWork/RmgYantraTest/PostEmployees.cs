﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpFrameWork.generic;
using RestSharpFrameWork.PocoClassRmgYantra.EmployeeController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameWork.RmgYantraTest
{
    [TestClass]
    public class PostEmployees : BaseClass
    {
        
        [TestMethod]
        [TestCategory("POST")]
        public void PostProject()
        {
            Utilitys ut = new Utilitys();
            string userName = "varu1nsn" + ut.RandomInt();

            IRestClient client=new RestClient("http://localhost:8084/");
            ODBCValidation userNameValid= new ODBCValidation();
            var odbcReaponse=userNameValid.Equals(userName);
            IRestRequest request = new RestRequest("employees", Method.POST);
            Employee emp=new Employee();
            var data=emp.employeeData(userName);
            

            /*var employee = new Employee
            {
                designation = "Automation Test Engineer",
                experience = 4.1,
                empName = "varu1n",
                email = "varu1nsn9@gmail.com",
                username = userName,
                project = "Unitte",
                role = "ROLE_EMPLOYEE",
                mobileNo = "9845632103"
            };
*/
            request.AddJsonBody(data);
            var response=client.Execute(request);
            Console.WriteLine(response.StatusCode);
            ODBCValidation od=new ODBCValidation();
            var validate= od.DataValidate(userName,"employee","username");
            Assert.IsTrue(response.IsSuccessful);
            Assert.IsTrue(validate);
            

        }
    }
}
