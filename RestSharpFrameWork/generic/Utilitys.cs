using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameWork.generic
{
    
    public  class Utilitys
    {
        
        public int RandomInt()
        {
            var random = new Random();
            int ran=random.Next(500);
            return ran;
        }
    }
}
