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
        /// </summary>
        /// <param name="Status">should provide a Status parameter
        /// </param>
        /// <returns></returns>
        public Project ProjectBody(String Status)
        {
            String status = Status; 
            Utilitys utilitys = new Utilitys();
            int num=utilitys.RandomInt();
            Project pro = new Project
            {
                createdBy = "varun",
                projectName = "Unitte"+num,
                status = status.ToString(),
                teamSize = 0

            };
            return pro;
        }
    }

    
}
