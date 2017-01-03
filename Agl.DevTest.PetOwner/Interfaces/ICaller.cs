using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Agl.DevTest.PetOwner.Models
{
    public interface ICaller
    {
        Task<Models.ServiceResponse> GetServiceResponseAsync(string baseDomainUrl, string serviceUri);
    }
}