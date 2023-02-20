using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpFrameWork.generic;
using RestSharpFrameWork.PocoClassRmgYantra.EmployeeController;

namespace RestSharpFrameWork.RmgYantraTest
{
    [TestClass]
    public class PostRmgTest : BaseClass
    {
        [TestMethod]
        [TestCategory("POST")]
        public void CreateEmployee()
        {
            IEndPoints endPoints = new EndPoints();

            cSharpUtilitys = new CSharpUtilitys();
            string userName = "varun" + cSharpUtilitys.RandomInt();
            IRestClient client = new RestClient("http://localhost:8084/");
            ODBCValidation userNameValid = new ODBCValidation();
            var odbcReaponse = userNameValid.Equals(userName);
            IRestRequest request = new RestRequest(endPoints.employees, Method.POST);
            Employee employee = new Employee();
            var data = employee.employeeData(userName);
            request.AddJsonBody(data);
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            ODBCValidation odbcValidation = new ODBCValidation();
            var validate = odbcValidation.DataValidate(userName, "employee", "username");
            Assert.IsTrue(response.IsSuccessful,"Not Created");
            Assert.IsTrue(validate,"odbcValidation validation failed");
        }

        [TestMethod]
        [TestCategory("POST")]
        public void AddProject()
        {
            IEndPoints endPoints = new EndPoints();
            Project project=new Project();
            IStatus status=new Status();
            restSharpUtils= new RestSharpUtils();
            ODBCValidation odbcvalidation=new ODBCValidation();
            var body=project.ProjectBody("teas",status.completed);
            var response=restSharpUtils.Post(endPoints.addProject,body);
            Assert.IsTrue(response.IsSuccessful,response.StatusCode.ToString());
            Assert.IsTrue(odbcvalidation.DataValidate(status.completed, "project", "status"), "no data found");
            
        }
    }
}
