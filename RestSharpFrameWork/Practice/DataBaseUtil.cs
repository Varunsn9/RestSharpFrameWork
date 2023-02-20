using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace RestSharpFrameWork.generic
{
    //Used for Testing only 
    //[TestClass]
    public class DataBaseUtil 
    {
        OdbcCommand command;

       [TestMethod,TestCategory("Practice")]
       public void odbc() {

            string connectionString = "Driver={MySQL ODBC 8.0 Unicode Driver};Server=localhost:3306;Database=projects;User=root;Password=root;";
            OdbcConnection connection = new OdbcConnection(connectionString);
            connection.Open();
            Console.WriteLine(connection.ConnectionString);
            Console.WriteLine(connection.ConnectionTimeout);
            Console.WriteLine(connection.Database);
            Console.WriteLine(connection.Driver);
            Console.WriteLine(connection.ServerVersion);
            string query = "select * from employee";
            OdbcCommand command= new OdbcCommand(query,connection);
            var response=command.ExecuteReader();
            while (response.Read())
            {
                Console.WriteLine(response[0]+" "+ response[1]+" " +response[2]+" "+response[3] + " " + response[4] + " " + response[5]);
            }
       }
    }
}
