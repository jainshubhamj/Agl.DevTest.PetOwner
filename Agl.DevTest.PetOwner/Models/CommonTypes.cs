using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agl.DevTest.PetOwner.Models
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }

    public class ServiceResponse : BaseResponse
    {
        public string Output { get; set; }
    }
}