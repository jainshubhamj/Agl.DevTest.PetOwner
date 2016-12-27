using System;

namespace Agl.DevTest.PetOwner
{
    public static class Constants
    {
        //Config Keys
        public const string PEOPLE_SERVICE_URL_CFG_KEY = "JsonServiceUrl";
        public const string BASE_DOMAIN_URL_CFG_KEY = "BaseDomainUrl";

        public static string BASE_DOMAIN_URL_DEFAULT = "http://agl-developer-test.azurewebsites.net";
        public const string PEOPLE_SERVICE_URL_DEFAULT = "/people.json";

        public const string MALE_TEXT = "Male";
        public const string FEMALE_TEXT = "Female";

        //Status Messages
        public const string SUCCESS_TEXT_MSG = "Success";
        public const string GET_DATA_ERROR_MSG = "Unable to get data, please try again later.";
        public const string UNKNOWN_ERROR_MSG = "Oops! something went wrong, please try again later.";
        public const string INVALID_INPUT_MSG = "Input is empty or invalid.";
                
    }

    public static class StatusCodeValues
    {
        public const int INVALID_INPUT = 100;
        public const int SUCCESS = 200;
        public const int SERVICE_CALL_ERROR = 500;
        public const int JSON_ERROR = 800;
        public const int UNKNOWN_ERROR = 900;
    }
}