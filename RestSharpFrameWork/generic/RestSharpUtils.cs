using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFrameWork.generic
{
    public class RestSharpUtils 
    {

        string apiClientUrl = "http://localhost:8084/";
        IRestRequest request;
        IRestClient client;

        public RestSharpUtils()
        {
            request= new RestRequest();
            client= new RestClient(apiClientUrl);
        }

        public IRestResponse Get(string endpoints)
        {
            // Create a new RestRequest object with the provided endpoint and HTTP GET method
            request = new RestRequest(endpoints, Method.GET);

            // Execute the request using a RestSharp RestClient object and store the response
            IRestResponse response = client.Execute(request);

            // Return the response object
            return response;
        }


        public IRestResponse Get( string endpoints,string value)
        {
            // Create a new RestRequest object with the provided endpoint and HTTP GET method
            request = new RestRequest(endpoints, Method.GET);

            // Add a URL segment to the request using the "employeeUserName" parameter
            request.AddUrlSegment("endpoint", value);

            // Execute the request using a RestSharp RestClient object and store the response
            IRestResponse response = client.Execute(request);

            // Return the response object
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoints"></param>
        /// <param name="value">string value to delete</param>
        /// <returns></returns>
        public IRestResponse Delete(string endpoints, string value)
        {
            // Create a new RestRequest object with the provided endpoint and HTTP DELETE method
            RestRequest request = new RestRequest(endpoints, Method.DELETE);

            // Add a URL segment to the request using the "employeeUserName" parameter
            request.AddUrlSegment("endpoint", value);

            // Execute the request using the provided IRestClient object and store the response
            IRestResponse response = client.Execute(request);

            // Return the response object
            return response;
        }

        public IRestResponse Put( string endpoints, Object jsonBody)
        {
            // Create a new RestRequest object with the provided endpoint and HTTP PUT method
            RestRequest request = new RestRequest(endpoints, Method.PUT);

            // Add the provided object as a JSON body to the request
            request.AddJsonBody(jsonBody);

            // Execute the request using the provided IRestClient object and store the response
            IRestResponse response = client.Execute(request);

            // Return the response object
            return response;
        }

        public IRestResponse Post(  string endpoints, Object jsonBody)
        {
            // Create a new RestRequest object with the provided endpoint and HTTP POST method
            RestRequest request = new RestRequest(endpoints, Method.POST);

            // Adds the provided object as a JSON body to the request using the AddJsonBody method of the RestRequest object
            request.AddJsonBody(jsonBody);

            // Sends the request to the endpoint using the IRestClient object named "client" and stores the response in an IRestResponse object
            IRestResponse response = client.Execute(request);
            
            // Returns the response object from the method
            return response;
        }


        public void validationCookies(IRestResponse response)
        {
            var cookies = response.Cookies;
            if (cookies != null)
            {

                foreach (var cookie in cookies)
                {
                    Console.WriteLine(cookie.Name);
                    Console.WriteLine(cookie.Value);
                    Console.WriteLine(cookie.Expires);
                    Console.WriteLine(cookie.Path);
                    Console.WriteLine(cookie.Domain);
                    Console.WriteLine(cookie.Secure);
                    Console.WriteLine(cookie.HttpOnly);

                }
            }
            else
            {
                Console.WriteLine("there are no cookies");
            }

        }

        public bool validationHeader(IRestResponse response, string value)
        {
            var headers = response.Headers;
            Console.WriteLine("Headers:");
            var boolValue = false;
            foreach (var header in headers)
            {
                if (value.Equals(header.Name) || value.Equals(header.Value))
                {
                    Console.WriteLine("Name: " + header.Name);
                    Console.WriteLine("Value: " + header.Value);
                    Console.WriteLine("------------------------------");
                    boolValue = true;
                }
               
            }
            return boolValue;

        }

        public bool validateJsonPath(IRestResponse response, string jsonPath)
        {
            try
            {
                JsonConvert.DeserializeObject(response.Content);
                var value = JObject.Parse(response.Content).SelectToken(jsonPath);
                return value != null;
            }
            catch (JsonException)
            {
                return false;
            }
        }

        public bool validationJSONBody(IRestResponse response, string jsonBody)
        {
            try
            {
                var json = JsonConvert.DeserializeObject(response.Content);
                return json.ToString().Contains(jsonBody);
            }
            catch (JsonException)
            {
                return false;
            }
        }

    }
}
