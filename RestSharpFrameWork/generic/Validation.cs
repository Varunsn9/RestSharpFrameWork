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
    public class Validation
    {
        public void CookiesValidation(IRestResponse response)
        {
            var cookies=response.Cookies;
            if (cookies != null)
        {

            foreach(var cookie in cookies)
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

        public void HeaderValidation(IRestResponse response,string value)
        {
            var headers = response.Headers;
            Console.WriteLine("Headers:");
            foreach (var header in headers)
            {
                if (value.Equals(header.Name) || value.Equals(header.Value))
                {
                    Console.WriteLine("Name: " + header.Name);
                    Console.WriteLine("Value: " + header.Value);
                    Console.WriteLine("------------------------------");
                }
            }
            
        }

        public bool ValidateJsonPath(IRestResponse response, string jsonPath)
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

        public bool JSONBodyValidation(IRestResponse response, string jsonBody)
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
