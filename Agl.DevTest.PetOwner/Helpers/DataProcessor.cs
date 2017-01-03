using Agl.DevTest.PetOwner.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agl.DevTest.PetOwner.Helpers
{
    /// <summary>
    /// Filter, sort and process data
    /// </summary>
    public class DataProcessor : IDataProcessor
    {

        //Note : SortByPetTypeLINQ is implemented by full LINQ but
        //       SortByPetType is used for better performance

        /// <summary>
        /// Filter the List of Owners by Pet Type, Create dictionary for Gender wise Names and sort alphabetically
        /// </summary>
        /// <param name="lstOwnerDetails">List of Owners</param>
        /// <param name="type">Pet Type for filtering</param>
        /// <returns>Dictionary of Gender wise Names of the owners</returns>
        [Obsolete("This method is deprecated, please use SortByPetType instead.")]
        public Dictionary<string, List<string>> SortByPetTypeLINQ(List<Models.OwnerDetail> lstOwnerDetails, string type)
        {
            Dictionary<string, List<string>> dictOwnersName = new Dictionary<string, List<string>>();
            if (lstOwnerDetails != null && !string.IsNullOrWhiteSpace(type))
            {
                try
                {
                    var lstOwner = lstOwnerDetails.Where(o => o.Gender == Constants.MALE_TEXT
                                                            && o.Pets != null
                                                            && o.Pets.Exists(p => p != null && string.Equals(p.Type, type, StringComparison.OrdinalIgnoreCase))
                                                            ).Select(on => on.Name).OrderBy(name => name).ToList();
                    
                    if (lstOwner.Count > 0)
                    {
                        dictOwnersName.Add(Constants.MALE_TEXT, lstOwner);
                    }

                    lstOwner = lstOwnerDetails.Where(o => o.Gender == Constants.FEMALE_TEXT
                                                            && o.Pets != null
                                                            && o.Pets.Exists(p => p != null && string.Equals(p.Type, type, StringComparison.OrdinalIgnoreCase))
                                                            ).Select(on => on.Name).OrderBy(name => name).ToList();


                    if (lstOwner.Count > 0)
                    {
                        dictOwnersName.Add(Constants.FEMALE_TEXT, lstOwner);
                    }

                }
                catch (Exception ex)
                {
                    // Log Exception
                    throw;
                }
            }

            return dictOwnersName;

        }

        /// <summary>
        /// Filter the List of Owners by Pet Type, Create dictionary for Gender wise Names and sort alphabetically
        /// </summary>
        /// <param name="lstOwnerDetails">List of Owners</param>
        /// <param name="type">Pet Type for filtering</param>
        /// <returns>Dictionary of Gender wise Names of the owners</returns>
        public Dictionary<string, List<string>> SortByPetType(List<Models.OwnerDetail> lstOwnerDetails, string type)
        {
            Dictionary<string, List<string>> dictOwnersName = new Dictionary<string, List<string>>();
            if (lstOwnerDetails != null && !string.IsNullOrWhiteSpace(type))
            {
                try
                {
                    List<string> lstMaleNames = new List<string>();
                    List<string> lstFemaleNames = new List<string>();
                    foreach (var owner in lstOwnerDetails)
                    {
                        if (owner != null && owner.Pets != null && owner.Pets.Exists(p => p != null && string.Equals(p.Type, type, StringComparison.OrdinalIgnoreCase)))
                        {
                            if (owner.Gender == Constants.MALE_TEXT )
                            {
                                lstMaleNames.Add(owner.Name);
                            }
                            else if (owner.Gender == Constants.FEMALE_TEXT)
                            {
                                lstFemaleNames.Add(owner.Name);
                            }

                        }
                    }

                    if (lstMaleNames.Count > 0)
                    {
                        lstMaleNames.Sort();
                        dictOwnersName.Add(Constants.MALE_TEXT, lstMaleNames);
                    }

                    if (lstFemaleNames.Count > 0)
                    {
                        lstFemaleNames.Sort();
                        dictOwnersName.Add(Constants.FEMALE_TEXT, lstFemaleNames);
                    }

                }
                catch (Exception ex)
                {
                    // Log Exception
                    throw;
                }
            }

            return dictOwnersName;

        }
    }
}