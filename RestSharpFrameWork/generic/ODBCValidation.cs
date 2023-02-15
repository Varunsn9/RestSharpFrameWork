using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpFrameWork.PocoClassRmgYantra.EmployeeController;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;

namespace RestSharpFrameWork.generic
{
    [TestClass]   
    public class ODBCValidation : BaseClass
    {
        OdbcCommand command;


        /// <summary>
        /// DataValidate method is used to validate provide bool value
        /// </summary>
        /// <param name="expectedData">string data to verify</param>
        /// <param name="tableName">string table name data </param>
        /// <param name="columnName">string column name of the data </param>
        /// <returns></returns>
        public bool DataValidate(string expectedData, string tableName , string columnName)
        {
            OdbcConnection connection = new OdbcConnection(dataBaseConnection);
            connection.Open();
            string query = "select "+columnName+" from "+tableName+" where "+columnName+ "="+"'"+ expectedData+"'";
            command = new OdbcCommand(query,connection);
            var response=command.ExecuteReader();
            while (response.Read())
            {
                Console.WriteLine(response[0]);
                if (expectedData.Equals(response[0])){
                    return true;
                    break;
                }
                
            }
            
            return false;
        }
        /// <summary>
        /// Simple test method to test ODBCValidation class 
        /// </summary>
        [TestMethod]
        [TestCategory("ODBC")]
        public void testingColumns()
        {
            ODBCValidation od=new ODBCValidation();
            var response=od.Table("employee");
            foreach(string res in response)
            {
                Console.WriteLine(res);
            }
            var user= od.ColumnData("employee","emp_id");
            foreach(var use in user)
            {
                Console.WriteLine(use);
            }
            var user1 = od.ColumnData("project", "created_by");
            foreach (var use in user1)
            {
                Console.WriteLine(use);
            }
            var tpe=od.DataValidate("Unitte", "project", "project_name");
            Console.WriteLine(tpe);
        }
        /// <summary>
        /// Method to return entire table return IList<string> 
        /// </summary>
        /// <param name="tableName">table name to fetch the data from</param>
        /// <returns></returns>
        public IList<string> Table(string tableName)
        {
            OdbcConnection connection = new OdbcConnection(dataBaseConnection);
            connection.Open();
            string query = "select * from " + tableName;
            command = new OdbcCommand(query, connection);
            var response = command.ExecuteReader();
            string row = "";

            IList<string> columns = new List<string>();
            while (response.Read())
            {
                 columns.Add(response[0].ToString()+"  "+ 
                     response[1].ToString() + "  " +
                     response[2].ToString() + "  " +
                     response[3].ToString() + "  " + 
                     response[4].ToString() + "  " + 
                     response[5].ToString() + "  " +
                     response[6].ToString() + "  " + 
                     response[7].ToString() + "  " + 
                     response[8].ToString() + "  " + 
                     response[9].ToString() + "  " +
                     response[10].ToString());
            }
            return columns;
        }
        /// <summary>
        /// method to return the data present in the columns return IList<string>
        /// </summary>
        /// <param name="tableName">provide the tableName to fetch the data from</param>
        /// <param name="columnName">provide the columnName to fetch the data from</param>
        /// <returns></returns>
        public IList<string> ColumnData(string tableName,string columnName)
        {
            OdbcConnection connection = new OdbcConnection(dataBaseConnection);
            connection.Open();
            string query = "select "+columnName+" from "+tableName;
            command = new OdbcCommand(query, connection);
            var response = command.ExecuteReader();
            int num = 0;
           
            IList<string> name = new List<string>();
            while (response.Read())
            {
                name.Add(response[0].ToString());

             }
            return name;
        }

    }
   

}
