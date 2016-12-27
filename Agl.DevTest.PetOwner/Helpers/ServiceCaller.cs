using Agl.DevTest.PetOwner.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Agl.DevTest.PetOwner.Helpers
{
    public class ServiceCaller : ICaller
    {
        /// <summary>
        /// Calls an HTTP service and gets the string response
        /// </summary>
        /// <param name="serviceUri">Service URL</param>
        /// <returns>Response object containing Status and JSON string</returns>
        public async Task<Models.ServiceResponse> GetServiceResponseAsync(string baseDomainUrl, string serviceUri)
        {
            //TODO: Log Entry with URL
            Models.ServiceResponse svcResponse = new Models.ServiceResponse();
            svcResponse.StatusCode = StatusCodeValues.SUCCESS;
            svcResponse.StatusMessage = Constants.SUCCESS_TEXT_MSG;
            svcResponse.Output = string.Empty;

            if (string.IsNullOrWhiteSpace(baseDomainUrl) || string.IsNullOrWhiteSpace(serviceUri))
            {
                svcResponse.StatusCode = StatusCodeValues.INVALID_INPUT;
                svcResponse.StatusMessage = Constants.INVALID_INPUT_MSG;
                return svcResponse;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseDomainUrl);
                    using (HttpResponseMessage response = await client.GetAsync(serviceUri))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            svcResponse.Output = await response.Content.ReadAsStringAsync();
                        }
                        else
                        {
                            svcResponse.StatusCode = (int)response.StatusCode;
                            svcResponse.StatusMessage = response.StatusCode.ToString();
                            //TODO: Log Exception
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                svcResponse.StatusCode = StatusCodeValues.SERVICE_CALL_ERROR;
                svcResponse.StatusMessage = ex.Message;
                //TODO: Log Exception
            }
            return svcResponse;
        }

    }
}