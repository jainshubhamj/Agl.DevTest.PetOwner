using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agl.DevTest.PetOwner.Models
{
    public interface IDataProcessor
    {
        Dictionary<string, List<string>> SortByPetTypeLINQ(List<Models.OwnerDetail> lstOwnerDetails, string type);
        
        Dictionary<string, List<string>> SortByPetType(List<Models.OwnerDetail> lstOwnerDetails, string type);
    }
}