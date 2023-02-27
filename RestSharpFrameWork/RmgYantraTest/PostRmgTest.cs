using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytescout.Spreadsheet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpFrameWork.generic;
using RestSharpFrameWork.PocoClassRmgYantra.EmployeeController;

namespace RestSharpFrameWork.RmgYantraTest
{
    [TestClass]
    public class PostRmgTest : BaseClass
    {
        IEndPoints endPoints = new EndPoints();
        Employee employee= new Employee();

        [TestMethod]
        [TestCategory("POST")]
        public void CreateEmployee()
        {
            
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
            //Object creation of particular classes
            Project project=new Project();
            IStatus status=new Status();
            restSharpUtils= new RestSharpUtils();
            ODBCValidation odbcvalidation=new ODBCValidation();
            
            //storing json body in project type in ProjectBody
            //ProjectBody takes two string value project name and status
            var projectBody=project.ProjectBody("teas",status.completed);
                        
            //storing response from Post Method of RestSharpUtils class to post the projectBody 
            //creating project
            var response=restSharpUtils.Post(endPoints.addProject,projectBody);

            //validating response and if there are error message of response status code will be printed in console
            Assert.IsTrue(response.IsSuccessful,response.StatusCode.ToString()/* message */);
            
            //validating that the project is created inside the OBDC database
            Assert.IsTrue(odbcvalidation.DataValidate(status.completed, "project", "status"), "no data found");
                
        }

        [TestMethod]
        [TestCategory("POST")]
        [DynamicData(nameof(Employee),DynamicDataSourceType.Method)]
        public void DataDriverCreateEmployee(string designation, string experience, string empName, string email, string username, string project, string role, string mobileNo) {
            Employee employee = new Employee();
            restSharpUtils = new RestSharpUtils();
            ODBCValidation odbcvalidation = new ODBCValidation();

            var employeeBody = employee.employeeData(designation,experience,empName,email,username,project,role,mobileNo);
            var response = restSharpUtils.Post(endPoints.employees, employeeBody);
            Assert.IsTrue(response.IsSuccessful);    
        }

        [TestMethod]
        [TestCategory("POST")]
        [DynamicData(nameof(Project), DynamicDataSourceType.Method)]
        public void DataDriverAddProject(string createdBy,string projectName, string status,string teamsize)
        {
            Employee employee = new Employee();
            restSharpUtils = new RestSharpUtils();
            ODBCValidation odbcvalidation = new ODBCValidation();
            Project project = new Project();
            var projectBody=project.ProjectBody(createdBy, projectName, status, teamsize);
            var response = restSharpUtils.Post(endPoints.addProject,projectBody );
            Assert.IsTrue(response.IsSuccessful,response.Content);
        }


        public static IEnumerable<object[]> Employee()
        {
            Spreadsheet spreadsheet = new Spreadsheet();
            spreadsheet.LoadFromFile("C:\\Users\\VARUN SN\\Desktop\\RestSharp\\RestSharpFrameWork\\RestSharpFrameWork\\Resources\\Data.xlsx");
            var sheet = spreadsheet.Workbook.Worksheets["EMPLOYEE"];
            var maxROW = sheet.UsedRangeRowMax;
            var maxcol = sheet.UsedRangeColumnMax;

            for (int i = 1; i <= maxROW; i++)
            {
                string designation = sheet.Cell(i, 0).ToString();
                string experience = sheet.Cell(i, 1).ToString();
                string empName = sheet.Cell(i, 2).ToString();
                string email = sheet.Cell(i, 3).ToString();
                string username = sheet.Cell(i, 4).ToString();
                string project = sheet.Cell(i, 5).ToString();
                string role = sheet.Cell(i, 6).ToString();
                string mobileNo = sheet.Cell(i, 7).ToString();
                yield return new object[] { designation, experience, empName, email, username, project, role, mobileNo };

            }
        }
        
        //project from excel Data.xlsx sheetname "PROJECT"
        public static IEnumerable<object[]> Project()
        {
            Spreadsheet spreadsheet = new Spreadsheet();
            spreadsheet.LoadFromFile("C:\\Users\\VARUN SN\\Desktop\\RestSharp\\RestSharpFrameWork\\RestSharpFrameWork\\Resources\\Data.xlsx");
            var sheet = spreadsheet.Workbook.Worksheets["PROJECT"];
            var maxROW = sheet.UsedRangeRowMax;
            var maxcol = sheet.UsedRangeColumnMax;

            for (int i = 1; i < maxROW; i++)
            {
                string createdBy = sheet.Cell(i, 0).ToString();
                string projectName = sheet.Cell(i, 1).ToString();
                string status = sheet.Cell(i, 2).ToString();
                string teamsize = sheet.Cell(i, 3).ToString();
                yield return new object[] { createdBy,projectName,status,teamsize };

            }
        }


    }
}
