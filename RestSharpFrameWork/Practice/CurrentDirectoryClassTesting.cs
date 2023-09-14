using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpFrameWork.generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameWork.Practice
{
    [TestClass]
    public class CurrentDirectoryClassTesting
    {
        [TestMethod]
        [TestCategory("TestIngCurrentDirectory")]
        public void TestIngCurrentDirectory()
        {
            Console.WriteLine(PathsConsts.currentDirectory); 
        }
    }
}
