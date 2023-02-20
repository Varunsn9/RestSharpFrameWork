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
    
    public class PostProject : BaseClass
    {
        [TestMethod]
        [TestCategory("Practice")]
        public void PostProjectTest() 
        {
            RestSharpUtils rt= new RestSharpUtils();
            
            Project p=new Project();
            Status status=new Status();
            var body=p.ProjectBody("nextLevel",status.created);
            var response=rt.Post(endPoints.addProject,body);
            Console.WriteLine(response.Content);
        }
    }
}
