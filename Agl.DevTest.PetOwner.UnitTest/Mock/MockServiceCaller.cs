using Agl.DevTest.PetOwner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agl.DevTest.PetOwner.UnitTest.Models
{
    class MockServiceCaller : ICaller
    {
        private List<string> _lstMockJsonResponse;

        public MockServiceCaller()
        {
            string strJsonResp;
            _lstMockJsonResponse = new List<string>();
            strJsonResp = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";
            _lstMockJsonResponse.Add(strJsonResp);
        }
        public async Task<ServiceResponse> GetServiceResponseAsync(string baseDomainUrl, string serviceUri)
        {
            ServiceResponse svcResponse = new ServiceResponse();
            svcResponse.StatusCode = StatusCodeValues.SUCCESS;
            svcResponse.StatusMessage = Constants.SUCCESS_TEXT_MSG;
            svcResponse.Output = string.Empty;

            if (string.IsNullOrWhiteSpace(baseDomainUrl) || string.IsNullOrWhiteSpace(serviceUri))
            {
                svcResponse.StatusCode = StatusCodeValues.INVALID_INPUT;
                svcResponse.StatusMessage = Constants.INVALID_INPUT_MSG;
                return svcResponse;
            }

            svcResponse.Output = _lstMockJsonResponse.FirstOrDefault();
            return svcResponse;
        }
    }
}
