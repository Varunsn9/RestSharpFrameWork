using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using TechTalk.SpecFlow.Events;
using Assert = NUnit.Framework.Assert;

namespace RestSharpFrameWork
{/// <summary>
/// TestMethods for testing
/// </summary>
    //[TestClass]
    public class UnitTest1
    {
        string url = "http://localhost:3000/";

        [TestMethod]
        [TestCategory("Practice")]
        public void Deserialize() 
        {
            RestClient client = new RestClient("http://localhost:3000/");

            var request = new RestRequest( "posts/{postid}",Method.GET);
            request.AddUrlSegment("postid", 1 );

            var response=client.Execute(request);
            var content = client.Execute(request).Content;
            Console.WriteLine(content);
            var deserial = new JsonDeserializer();
            Console.WriteLine(content);
            var output=deserial.Deserialize<Dictionary<string, string>>(response);
            string result = output["id"];
            Console.WriteLine(result);
            NUnit.Framework.Assert.That(result, Is.EqualTo("1"), "id is not correct");

        }
        [TestMethod]
        [TestCategory("Practice")]
        public void DeserializationJsonObj()
        {
            RestClient client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);
            var content = client.Execute(request).Content;
            Console.WriteLine(content);
            var obj=JObject.Parse(content);
            NUnit.Framework.Assert.That(obj["author"].ToString, Is.EqualTo("Varun SN"), "Author is not correct");

        }

        [TestMethod]//using RmgYamtra employees
        [TestCategory("Practice")]
        public void TestingJsonServerEmployees()
        {
            RestClient client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("employee", Method.GET);
            var response = client.Execute(request);
            var content = client.Execute(request).Content;
            Console.WriteLine(content);

        }
        [TestMethod]
        [TestCategory("Practice")]
        public void postProfile()
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("post/1/profile", Method.GET);
            //request.AddUrlSegment("postid", 1);
            var output = client.Execute(request);
            Console.WriteLine(output.Content);
            Console.WriteLine(output.StatusCode);
        }
        [TestMethod]
        [TestCategory("Practice")]
        public void PostingProfile()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("/comments/4", Method.DELETE);
            //request.AddJsonBody(new { name="Hemanth", orgName="TestYantra" });
           
           

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [TestMethod]
        [TestCategory("Practice")]
        public void postCreating_Comments()
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest("/comments/5", Method.DELETE);
            request.AddJsonBody(new { name = "Yusuf", orgName = "TestYantra" });
            var output = client.Execute(request);
            Console.WriteLine(output.Content);
            NUnit.Framework.Assert.AreEqual(HttpStatusCode.OK, output.StatusCode);

        }
    }
}
