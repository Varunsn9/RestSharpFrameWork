using Bytescout.Spreadsheet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class DeleteRmgTest : BaseClass
    {
        [TestMethod]
        [TestCategory("DELETE")]
        public void EmployeeDelete(/*string employeeId*/)
        {
            endPoints =new EndPoints();
            restSharpUtils = new RestSharpUtils();
            var response=restSharpUtils.Delete(endPoints.employeesId, "TYP_01072");
            Assert.IsTrue(response.IsSuccessful, response.Content);
        }

        [TestMethod]
        [TestCategory("DELETE")]
        [DynamicData(nameof(ExcelDataEmployee),DynamicDataSourceType.Method)]
        public void EmployeeDeleteById(string employeeId)
        {
            endPoints = new EndPoints();
            restSharpUtils = new RestSharpUtils();
            var response = restSharpUtils.Delete(endPoints.employeesId, employeeId);
            Assert.IsTrue(response.IsSuccessful, response.Content);
        }

        

        [TestMethod]
        [TestCategory("DELETE")]
        [DynamicData(nameof(ExcelDataProject), DynamicDataSourceType.Method)]
        public void ProjectDeleteById(string projectId)
        {
            endPoints = new EndPoints();
            restSharpUtils = new RestSharpUtils();
            var response = restSharpUtils.Delete(endPoints.projectsId, projectId);
            Assert.IsTrue(response.IsSuccessful, response.Content);
        }
       

        public static IEnumerable<object[]> ExcelDataEmployee()
        {
            Spreadsheet spreadsheet = new Spreadsheet();
            spreadsheet.LoadFromFile(PathsConsts.excelPath);
            var sheet = spreadsheet.Workbook.Worksheets["EMPLOYEEID"];
            var maxrow = sheet.UsedRangeRowMax;
            var maxcol = sheet.UsedRangeColumnMax;

            for (int i = 1; i <= maxrow; i++)
            {
                string employeeId = sheet.Cell(i, 0).ToString();
                yield return new object[] { employeeId };
            }

        }


        public static IEnumerable<object[]> ExcelDataProject()
        {
            Spreadsheet spreadsheet = new Spreadsheet();
            spreadsheet.LoadFromFile(PathsConsts.excelPath);
            var sheet = spreadsheet.Workbook.Worksheets["PROJECTID"];
            var maxrow = sheet.UsedRangeRowMax;
            var maxcol = sheet.UsedRangeColumnMax;

            for (int i = 1; i <= maxrow; i++)
            {
                string projectId = sheet.Cell(i, 0).ToString();
                yield return new object[] { projectId };
            }


        }
    }
}
