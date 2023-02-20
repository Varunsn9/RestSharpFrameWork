using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameWork.generic
{
    
    public  class CSharpUtilitys
    {
        /// <summary>
        /// Random method to generate numbers
        /// </summary>
        /// <returns></returns>
        public int RandomInt()
        {
            var random = new Random();
           int ran=random.Next(500);
           

            return ran;
        }
        public long Randomlong()
        {
            var random = new Random();
            long ran = random.Next(100000000, 999999999);
            long mobNum = ran + 1000000000;

            return mobNum;
        }
    }
}
