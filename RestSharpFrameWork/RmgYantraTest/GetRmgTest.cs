using Bytescout.Spreadsheet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using RestSharpFrameWork.generic;
using RestSharpFrameWork.PocoClassRmgYantra.EmployeeController;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameWork.RmgYantraTest
{
    [TestClass]
    public class GetRmgTest : BaseClass
    {
        string UserName = "varunsn";
        string empId = "TYP_01066";
        string projectName = "ynittee";
        string projectId = "TY_PROJ_1455";

        [TestMethod]
        [TestCategory("GET")]
        public void getEmpByUserName()
        {
            
            restSharpUtils = new RestSharpUtils();
            endPoints = new EndPoints();
            var response = restSharpUtils.Get(endPoints.employeesUserName, UserName);
            Employee employee = new Employee();
            var user=employee.employeeData(UserName);
            Assert.IsTrue(response.IsSuccessful,"IsSuccessful");

            // Validate response JSONBody
            Assert.IsTrue(restSharpUtils.validationJSONBody(response, UserName));
           
            // Validate response status code
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Unexpected status code");

            // Validate response headers
            Assert.AreEqual("application/json", response.ContentType    , "Unexpected content type");
        }


        [TestMethod]
        [TestCategory("GET")]
        public void getAllEmployees()
        {
            endPoints = new EndPoints();
            restSharpUtils = new RestSharpUtils();
            var response = restSharpUtils.Get(endPoints.employees);
            Assert.IsTrue(response.IsSuccessful, "IsSuccessful");

            // Validate response JSONBody
            Assert.IsTrue(restSharpUtils.validationJSONBody(response,UserName));

            // Validate response status code
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Unexpected status code");

            // Validate response headers
            Assert.AreEqual("application/json", response.ContentType, "Unexpected content type");


        }
        [TestMethod]
        [TestCategory("GET")]
        public void getEmployeeById()
        {
            endPoints = new EndPoints();
            restSharpUtils = new RestSharpUtils();
            var response = restSharpUtils.Get(endPoints.employeesId,empId);

            Assert.IsTrue(response.IsSuccessful, "IsSuccessful");
         
            // Validate response JSONBody
            Assert.IsTrue(restSharpUtils.validationJSONBody(response, empId));

            // Validate response status code
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Unexpected status code");

            // Validate response headers
            Assert.AreEqual("application/json", response.ContentType, "Unexpected content type");

        }

        [TestMethod]
        [TestCategory("GET")]
        public void GetAllProjects()
        {
            endPoints = new EndPoints();
            restSharpUtils = new RestSharpUtils();
            var response = restSharpUtils.Get(endPoints.projects);
            Assert.IsTrue(response.IsSuccessful, "Not Successful");

            // Validate response JSONBody
            Assert.IsTrue(restSharpUtils.validationJSONBody(response, projectName),response.Content);

            // Validate response status code
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Unexpected status code");

            // Validate response headers
            Assert.AreEqual("application/json", response.ContentType, "Unexpected content type");

        }
        [TestMethod]
        [TestCategory("GET")]
        public void GetSingleProject()
        {
            endPoints = new EndPoints();
            restSharpUtils = new RestSharpUtils();
            var response = restSharpUtils.Get(endPoints.projectsId,projectId);
            Assert.IsTrue(response.IsSuccessful, "UnExpected response IsSuccessful");

            // Validate response JSONBody
            Assert.IsTrue(restSharpUtils.validationJSONBody(response, projectId));

            // Validate response status code
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Unexpected status code");

            // Validate response headers
            Assert.AreEqual("application/json", response.ContentType, "Unexpected content type");

        }

        [TestMethod]
        [TestCategory("GET")]
        [DynamicData(nameof(EmployeeUserName),DynamicDataSourceType.Method)]
        public void EmployeeByUserNameTest(string username)
        {
            endPoints=new EndPoints();
            restSharpUtils = new RestSharpUtils();
            var response = restSharpUtils.Get(endPoints.employeesUserName, username);
            Assert.IsTrue(response.IsSuccessful);
        }


        public static IEnumerable<object[]> EmployeeUserName()
        {
            Spreadsheet spreadsheet = new Spreadsheet();
            spreadsheet.LoadFromFile("C:\\Users\\VARUN SN\\Desktop\\RestSharp\\RestSharpFrameWork\\RestSharpFrameWork\\Resources\\Data.xlsx");
            var sheet = spreadsheet.Workbook.Worksheets["EMPLOYEE"];
            var maxROW = sheet.UsedRangeRowMax;
            var maxcol = sheet.UsedRangeColumnMax;

            for (int i = 1; i < maxROW; i++)
            {
                string username = sheet.Cell(i, 4).ToString();
                yield return new object[] { username };

            }
        }

        public static IEnumerable<object[]> EmployeeById()
        {
            Spreadsheet spreadsheet = new Spreadsheet();
            spreadsheet.LoadFromFile("C:\\Users\\VARUN SN\\Desktop\\RestSharp\\RestSharpFrameWork\\RestSharpFrameWork\\Resources\\Data.xlsx");
            var sheet = spreadsheet.Workbook.Worksheets["EMPLOYEE"];
            var maxROW = sheet.UsedRangeRowMax;
            var maxcol = sheet.UsedRangeColumnMax;

            for (int i = 1; i < maxROW; i++)
            {
                string username = sheet.Cell(i, 4).ToString();
                yield return new object[] { username };

            }
        }

    }
}
