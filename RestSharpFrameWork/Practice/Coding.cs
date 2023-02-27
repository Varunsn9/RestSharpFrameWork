using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameWork.Practice
{
    //[TestClass]
    public  class Coding
    {
        [TestMethod,TestCategory("coding")]
        public void sum()
        {
            string name = "sum";
            string value = "";
            string[] output = new string[name.Length];


            for(int i = 0; i < name.Length; i++)
            {
                    value += name[i];
                    output[i] = value;
                    Console.Write(output[i]+ " ");
            }
            string nam = "";
            for(int i = 1; i < name.Length; i++)
            {
                nam = "";
                for(int j=i; j < name.Length; j++)
                {
                    nam = nam+name[j];
                    
                }
                Console.Write(nam + " ");
            }

            
            
            
        }
    }
}
