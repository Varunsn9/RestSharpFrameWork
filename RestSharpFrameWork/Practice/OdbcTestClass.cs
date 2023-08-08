using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpFrameWork.generic;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameWork.Practice
{
    [TestClass]
    public class OdbcTestClass : BaseClass
    {
        [TestMethod]
        [TestCategory("ODBC")]
        public void obdc()
        {
            string connections = PathsConsts.connectionString;
            OdbcConnection odbcConnection = new OdbcConnection(connections);
            odbcConnection.Open();
            
            string query = "select count(username) from employee";
            Console.WriteLine(odbcConnection.ToString());
            OdbcCommand odbcCommand=new OdbcCommand(query, odbcConnection);
            var response=odbcCommand.ExecuteReader();
            response.Read();
            Console.WriteLine(response[0]);
            
        }

        /// <summary>
        /// Simple test method to test ODBCValidation class 
        /// </summary>
        [TestMethod]
        [TestCategory("ODBC")]
        public void testingColumns()
        {
          var list=oDBCValidation.ColumnData("employee","username");
            foreach(string lis in list)
            {
                Console.WriteLine(lis);
            }
        }
    }
}
