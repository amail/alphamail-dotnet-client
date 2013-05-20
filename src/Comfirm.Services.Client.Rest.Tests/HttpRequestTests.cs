using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comfirm.Services.Client.Rest.Core;
using System.Diagnostics;

namespace Comfirm.Services.Client.Rest.Tests
{
    [TestClass]
    public class HttpRequestTests
    {
        private const string HttpExampleTestServer = "http://httpbin.org/";

        [TestMethod]
        public void CanInstantiateWithoutExceptions()
        {
            try
            {
                new HttpRequest();
            }
            catch (Exception exception)
            {
                Assert.Fail("Instantiation threw an exception: " + exception.Message);
            }
        }

        [TestMethod]
        public void CanMakeGetRequest()
        {
            try
            {
                var request = new HttpRequest();
                var response = request.RequestRaw(HttpMethodType.Get, HttpExampleTestServer);
                Assert.IsNotNull(response);
                Assert.IsTrue(!String.IsNullOrEmpty(response.Result));
            }
            catch (Exception exception)
            {
                Assert.Fail("Instantiation threw an exception: " + exception.Message);
            }
        }

        [TestMethod]
        public void CanMakePostRequest()
        {
            try
            {
                const string postDummyBody = "test=test&test2=test";
                var request = new HttpRequest();
                var response = request.RequestRaw<string>(HttpMethodType.Post, HttpExampleTestServer + "post", null, postDummyBody);
                Assert.IsTrue(!String.IsNullOrEmpty(response.Result));
            }
            catch (Exception exception)
            {
                Assert.Fail("Instantiation threw an exception: " + exception.Message);
            }
        }
    }
}
