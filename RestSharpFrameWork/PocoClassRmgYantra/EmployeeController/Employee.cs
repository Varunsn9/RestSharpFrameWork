using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharpFrameWork.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestSharpFrameWork.PocoClassRmgYantra.EmployeeController
{
    
    public class Employee
    {
        [JsonProperty("designation")]
        public string designation { get; set; }

        [JsonProperty("dob")]
        public string dob { get; set; }
        
        [JsonProperty("email")]
        public string email { get; set; }
        
        [JsonProperty("empName")]
        public string empName { get; set; }
        
        [JsonProperty("experience")]
        public double experience { get; set; }
        
        [JsonProperty("mobileNo")]
        public string mobileNo { get; set; }
        
        [JsonProperty("project")]
        public string project { get; set; }
        
        [JsonProperty("role")]
        public string role { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

public Employee employeeData(string userName) {
            var employee = new Employee
            {
                designation = "Automation Test Engineer",
                experience = 4.1,
                empName = "varu1n",
                email = "varu1nsn9@gmail.com",
                username = userName,
                project = "Unitte",
                role = "ROLE_EMPLOYEE",
                mobileNo = "9845632103"
            };
            return employee;
        }

    }

}
