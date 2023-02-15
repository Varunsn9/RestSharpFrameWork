using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    /// <summary>
    /// TestMethods for testing
    /// </summary>
    [TestClass]
    public class PostProject : BaseClass
    {
        [TestMethod]
        [TestCategory("POST")]
        public void PostProjectTest() 
        {
            RestSharpUtils rt= new RestSharpUtils();
            
            Project p=new Project();
            var body=p.ProjectBody("On Going");
            var response=rt.Post(EndPoints.addProject,body);
            Console.WriteLine(response.Content);
        }
    }
}
