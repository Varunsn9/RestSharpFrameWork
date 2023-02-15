using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestSharpFrameWork.generic
{ /// <summary>
  /// Endpoint for all the Api Testing
  /// </summary>
    public class EndPoints
    {
        /// <summary>
        /// employeeId is stored with "employees/{endpoint}"
        /// is used to perform action on employee by EmployeeID
        /// </summary>
        public static string employeesId="employees/{endpoint}";

        /// <summary>
        /// employeeId is stored with "employees" 
        /// </summary>
        public static string employees = "employees/";
        public static string employeesUserName = "employee/{endpoint}/";
        public static string login = "login";
        public static string error = "error";
        
        public static string addProject = "addProject/";
        public static string projects = "projects/";
        /// <summary>
        /// project id is for specifing perticular project for performing GET , PUT and Delete
        /// </summary>
        public static string projectsId = "projects/{projectId}";
    }
   
}
