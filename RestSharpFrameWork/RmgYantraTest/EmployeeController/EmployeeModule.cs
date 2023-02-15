using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpFrameWork.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameWork.RmgYantraTest.EmployeeController
{

    /// <summary>
    /// Test Methods
    /// </summary>
    [TestClass]
    [TestCategory("GetEmployee")]
    public class EmployeeModule
    {
        [TestMethod]
        [TestCategory("GET")]
        public void getEmpByUserName()
        {
            RestSharpUtils rt=new RestSharpUtils();
            var response=rt.Get(EndPoints.employeesUserName,"varunsn38");
            Console.WriteLine(response.IsSuccessful);
        }
    

    
        [TestMethod]
        [TestCategory("GET")]
        public void getAllEmployees()
        {
            RestSharpUtils rt = new RestSharpUtils();
            var response = rt.Get(EndPoints.employeesUserName, "varunsn38");
            Console.WriteLine(response.IsSuccessful);
            Assert.IsTrue(response.IsSuccessful);
            
        }
    }
}
