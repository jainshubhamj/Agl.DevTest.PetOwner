using Newtonsoft.Json;
using System;
using System.Configuration;

namespace Agl.DevTest.PetOwner.Helpers
{
    /// <summary>
    /// Provide static Configuration values and Utility methods
    /// </summary>
    public static class Utility
    {

        private static string baseDomainUrl;

        public static string BaseDomainUrl
        {
            get { return baseDomainUrl; }
        }

        private static string peopleServiceUri;

        public static string PeopleServiceUri
        {
            get { return peopleServiceUri; }
        }

        static Utility()
        {
            peopleServiceUri = ConfigurationManager.AppSettings[Constants.PEOPLE_SERVICE_URL_CFG_KEY];

            if (string.IsNullOrWhiteSpace(peopleServiceUri))
            {
                peopleServiceUri = Constants.PEOPLE_SERVICE_URL_DEFAULT;
            }

            baseDomainUrl = ConfigurationManager.AppSettings[Constants.BASE_DOMAIN_URL_CFG_KEY];

            if (string.IsNullOrWhiteSpace(baseDomainUrl))
            {
                baseDomainUrl = Constants.BASE_DOMAIN_URL_DEFAULT;
            }
        }

        /// <summary>
        /// Generic method to get object from JSON string
        /// </summary>
        /// <typeparam name="T">Type of object to be returned</typeparam>
        /// <param name="input">JSON string</param>
        /// <returns>Object of type T</returns>
        public static T GetObjectFromJson<T>(string input)
        {
            T objOutput = default(T);
            try
            {
                objOutput = JsonConvert.DeserializeObject<T>(input);
            }
            catch (Exception)
            {
                // Log Exception
            }
            return objOutput;
        }

    }
}