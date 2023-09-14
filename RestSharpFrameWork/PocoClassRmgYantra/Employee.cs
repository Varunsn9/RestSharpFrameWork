using Bytescout.Spreadsheet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharpFrameWork.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RestSharpFrameWork.PocoClassRmgYantra.EmployeeController
{
    /// <summary>
    /// Employee Poco Class
    /// </summary>
    /// 

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


        IDesignation design=new Designation();
        IRole roleObj = new Role(); 


        /// <summary>
        /// Method to return body of employee returns Employee type
        /// </summary>
        /// <param name="userName">changing only username 
        /// all the other data can be same</param>
        /// <returns></returns>
            public Employee employeeData(string userName) 
            {
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
            {
}
        }


        




        public Employee employeeData(string designation, string experience, string empName, string email, string username, string project, string role,string mobileNo)
        {
            Employee employee = new Employee
            {
                designation = designation,
                empName = empName,
                email = email,
                username = username,
                project = project,
                role = role,
                mobileNo = mobileNo
            };
            return employee;
        }

    }
    public interface IDesignation
    {
        string software_Engineer { get; set; }
        string sDET { get; set; }
        string automation_Test_Engineer { get; set; }
        string software_Developer { get; set; }
        string manual_Test_Engineer { get; set; }

    }
    public class Designation : IDesignation
    {
        public string software_Engineer { get; set; }
        public string sDET { get; set; }
        public string automation_Test_Engineer { get; set; }
        public string software_Developer { get; set; }
        public string manual_Test_Engineer { get; set; }


        public Designation()
        {
            software_Engineer = "Software Engineer";
            sDET = "SDET";
            automation_Test_Engineer = "Automation Test Engineer";
            software_Developer = "Software Developer";
            manual_Test_Engineer = "Manual Test Engineer";

        }
    }

    public interface IRole
    {
        string rOLE_ADMIN { get; set; }
        string rOLE_EMPLOYEE { get; set; }
       
    }
    public class Role : IRole
    {
        public string rOLE_ADMIN { get; set; }
        public string rOLE_EMPLOYEE { get; set; }
       

        public Role()
        {
            rOLE_ADMIN = "ROLE_ADMIN";
            rOLE_EMPLOYEE = "ROLE_EMPLOYEE";
        
        }
    }

}
