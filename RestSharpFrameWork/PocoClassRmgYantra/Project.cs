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
        /// <param name="Status">should provide a Status parameter
        /// </param>
        /// <returns></returns>
        public Project ProjectBody(string projectName, string status)
        {
            
            CSharpUtilitys utilitys = new CSharpUtilitys();
            int num = utilitys.RandomInt();
            Project pro = new Project
            {
                createdBy = "varun",
                projectName = projectName,
                status = status.ToString(),
                teamSize = 0

            };
            return pro;
        }
    }
    public interface IStatus
    {
        string created { get; set; }
        string completed { get; set; }
        string onGoging { get; set; }
    }
    public class Status : IStatus
    {
        public string created { get; set; }
        public string completed { get; set; }
        public string onGoging { get; set; }

        public Status()
        {
            created = "Created";
            completed = "Completed";
            onGoging = "OnGoing";
        }
}
    

    
}
