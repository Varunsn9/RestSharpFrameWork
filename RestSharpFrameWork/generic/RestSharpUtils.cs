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
             request = new RestRequest(endpoints,Method.GET);
            IRestResponse response=client.Execute(request);
            return response;
        }
        public IRestResponse Get( string endpoints,string employeeUserName)
        {
            request = new RestRequest(endpoints, Method.GET);
            request.AddUrlSegment("endpoint", employeeUserName);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse Delete(IRestClient client, string endpoints)
        {
            RestRequest request = new RestRequest(endpoints, Method.DELETE);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse Put( string endpoints, Object jsonBody)
        {
            RestRequest request = new RestRequest(endpoints, Method.PUT);
            request.AddJsonBody(jsonBody);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse Post(  string endpoints, Object jsonBody)
        {

            RestRequest request = new RestRequest(endpoints, Method.POST);
            request.AddJsonBody(jsonBody);
            IRestResponse response = client.Execute(request);
            return response;
        }

        
    }
}
