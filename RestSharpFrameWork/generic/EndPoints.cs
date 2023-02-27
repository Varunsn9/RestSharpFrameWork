using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestSharpFrameWork.generic
{ /// <summary>
  /// Endpoint for all the Api Testing
  /// </summary>

    public interface IEndPoints
    {
        /// <summary>
        /// To Get Update and Delete an employee by id
        /// </summary>
        string employeesId { get; set; }

        /// <summary>
        /// create employee/Post and Get all employees 
        /// </summary>
        string employees { get; set; }
       
        /// <summary>
        /// To Get an employee by UserName
        /// </summary>
        string employeesUserName { get; set; }

        /// <summary>
        /// To Get Authenticate
        /// </summary>
        string login { get; set; }

        /// <summary>
        /// To Get head post put delete options put patch error
        /// </summary>
        string error { get; set; }

        /// <summary>
        /// To Post a project/ create a project
        /// </summary>
        string addProject { get; set; }

        /// <summary>
        /// To Get All the projects
        /// </summary>
        string projects { get; set; }

        /// <summary>
        /// To Get Update/PUT and Delete an projects by id
        /// </summary>
        string projectsId { get; set; }
    }

        public class EndPoints : IEndPoints
    {

        public string employeesId { get; set; }
        public string employees { get; set; }
        public string employeesUserName { get; set; }
        public string login { get; set; }
        public string error { get; set; }
        public string addProject { get; set; }
        public string projects { get; set; }
        public string projectsId { get; set; }

        public EndPoints()
        {
              employeesId = "employees/{endpoint}/";
              employees = "employees/";
              employeesUserName = "employee/{endpoint}/";
              login = "login/";
              error = "error/";
              addProject = "addProject/";
              projects = "projects/";
              projectsId = "projects/{endpoint}/";
        }
    }
   
}
