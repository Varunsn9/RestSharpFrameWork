using Newtonsoft.Json;
using RestSharpFrameWork.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameWork.PocoClassRmgYantra.EmployeeController
{
    /// <summary>
    /// Project Poco Class
    /// </summary>
    public class Project
    {
        [JsonProperty("createdBy")]
        public string createdBy { get; set; }

        [JsonProperty("projectName")]
        public string projectName { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("teamSize")]
        public int teamSize { get; set; }


        /// <summary>
        /// Method to return body type of Employee
        /// Created, On Goging and Completed
        /// </summary>
        /// <param name="Status">should provide a string Status parameter
        /// </param>
        /// <param name="ProjectName">should provide a string ProjectName parameter
        /// </param>
        /// <returns></returns>
        public Project ProjectBody(string projectName,string status)
        {
            
            CSharpUtilitys utilitys = new CSharpUtilitys();
            int num = utilitys.RandomInt();
            Project pro = new Project
            {
                createdBy = "varun",
                projectName = projectName+num,
                status = status.ToString(),
                teamSize = 0

            };
            return pro;
        }

        public Project ProjectBody(string createdBy,string projectName, string status,string teamsize)
        {

            Project pro = new Project
            {
                createdBy = createdBy,
                projectName = projectName,
                status = status,
                teamSize = int.Parse(teamsize)

            };
            return pro;
        }
    }

    public interface IStatus
    {
        string Created { get; set; }
        string Completed { get; set; }
        string OnGoging { get; set; }
    }
    public class Status : IStatus
    {
        public string Created { get; set; }
        public string Completed { get; set; }
        public string OnGoging { get; set; }

        public Status()
        {
            Created = "Created";
            Completed = "Completed";
            OnGoging = "OnGoing";
        }
}
    

    
}
