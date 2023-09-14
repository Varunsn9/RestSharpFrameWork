using Bytescout.Spreadsheet;
using Dynamitey;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
//[assembly: Parallelize(Workers = 5, Scope = ExecutionScope.MethodLevel)]


namespace RestSharpFrameWork.generic
{
    

    public class BaseClass
    {
        public static TestContext testContext;
        public string dataBaseConnection = "Driver={MySQL ODBC 8.1 Unicode Driver};Server=localhost:3306;Database=projects;User=root;Password=root;";
        public static OdbcConnection odbcConnection;
        public ExcelUtility excelUtility;
        public ODBCValidation oDBCValidation;
        public RestSharpUtils restSharpUtils;
        public CSharpUtilitys cSharpUtilitys;
        public IEndPoints endPoints;

        [AssemblyInitialize]
        public static void AssemblyInilization(TestContext context)
        {
            Console.WriteLine("hi");
            testContext = context;
        }

        [ClassInitialize]
        public static void DataBase(TestContext context)
        {

        }

        [TestInitialize]
        public void OpeningDataBase()
        {
            testContext.WriteLine(testContext.TestName);
        }

        [TestCleanup]
        public void ClosingDataBase()
        {
        }

       

    }
}

