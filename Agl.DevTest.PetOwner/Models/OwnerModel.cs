using System;
using System.Collections.Generic;

namespace Agl.DevTest.PetOwner.Models
{

    public class AllOwnersViewModel : BaseResponse
    {
        public List<OwnerDetail> OwnerDetails { get; set; }
    }

    public class SortedOwnerViewModel : BaseResponse
    {
        public Dictionary<string, List<string>> GenderWiseNames { get; set; }
    }

    public class OwnerDetail
    {
        public string Name { get; set; }

        //TODO : Enum
        public string Gender { get; set; }

        public int Age { get; set; }

        public List<Pet> Pets { get; set; }
    }

    public class Pet
    {
        public string Name { get; set; }

        //TODO : Enum
        public string Type { get; set; }

    }


}