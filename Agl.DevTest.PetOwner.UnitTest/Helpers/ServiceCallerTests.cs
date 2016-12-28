using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agl.DevTest.PetOwner.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Agl.DevTest.PetOwner.Helpers.UnitTest
{
    [TestClass()]
    public class ServiceCallerTests
    {
        ServiceCaller _svcCaller;
                
        public ServiceCallerTests()
        {
            _svcCaller = new ServiceCaller();
        }

        [TestMethod()]
        public void GetServiceResponseAsyncTest_ValidInput()
        {
            //Arrange
            string baseUrl = Utility.BaseDomainUrl;
            string svcUri = Utility.PeopleServiceUri;

            //Act
            Models.ServiceResponse svcResponse = _svcCaller.GetServiceResponseAsync(baseUrl, svcUri).Result;

            //Assert
            Assert.IsNotNull(svcResponse);
            var objOutput = JsonConvert.DeserializeObject(svcResponse.Output);         
            Assert.AreEqual(svcResponse.StatusCode, StatusCodeValues.SUCCESS);
        }

        [TestMethod()]
        public void GetServiceResponseAsyncTest_NullInput()
        {
            Models.ServiceResponse svcResponse = _svcCaller.GetServiceResponseAsync(null, null).Result;

            Assert.IsNotNull(svcResponse);
            Assert.AreEqual(svcResponse.StatusCode, StatusCodeValues.INVALID_INPUT);
        }

        [TestMethod()]
        public void GetServiceResponseAsyncTest_IncorrectInput()
        {
            string baseUrl = "http://incorrect.incorrect";
            string svcUri = "/incorrect.json";
            Models.ServiceResponse svcResponse = _svcCaller.GetServiceResponseAsync(baseUrl, svcUri).Result;

            Assert.IsNotNull(svcResponse);
            Assert.AreNotEqual(svcResponse.StatusCode, StatusCodeValues.SUCCESS);
        }
        
        [TestMethod()]
        public void GetServiceResponseAsyncTest_404NotFound()
        {
            Models.ServiceResponse svcResponse = _svcCaller.GetServiceResponseAsync(Utility.BaseDomainUrl, "/abc.json").Result;

            Assert.IsNotNull(svcResponse);
            Assert.AreEqual(svcResponse.StatusCode, 404);
        }
    }
}
