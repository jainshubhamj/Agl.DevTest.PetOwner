using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Agl.DevTest.PetOwner.Helpers;
using Agl.DevTest.PetOwner.Models;

namespace Agl.DevTest.PetOwner.Controllers
{
    public class OwnerController : Controller
    {
        ICaller _svcHelper;
        IDataProcessor _dprocessor;

        public OwnerController() : this(new ServiceCaller(), new DataProcessor()) { }
        public OwnerController(ICaller caller, IDataProcessor dataprocessor)
        {
            _svcHelper = caller;
            _dprocessor = dataprocessor;
        }
        
        // GET: /Owner/
        public async Task<ActionResult> AllOwners()
        {
            Models.AllOwnersViewModel ownersViewModel = new Models.AllOwnersViewModel();

            Models.ServiceResponse svcResponse = await _svcHelper.GetServiceResponseAsync(Utility.BaseDomainUrl, Utility.PeopleServiceUri);

            if (svcResponse.StatusCode == StatusCodeValues.SUCCESS)
            {
                ownersViewModel.OwnerDetails = Utility.GetObjectFromJson<List<Models.OwnerDetail>>(svcResponse.Output);
                ownersViewModel.StatusCode = StatusCodeValues.SUCCESS;
                ownersViewModel.StatusMessage = Constants.SUCCESS_TEXT_MSG;
            }
            else
            {
                ownersViewModel.StatusCode = StatusCodeValues.SERVICE_CALL_ERROR;
                ownersViewModel.StatusMessage = Constants.GET_DATA_ERROR_MSG;
            }

            return View(ownersViewModel);
        }

        // GET: /Owner/SortedOwners        
        public async Task<ActionResult> SortedOwners(string pet)
        {
            Models.SortedOwnerViewModel sortedViewModel = new Models.SortedOwnerViewModel();

            if (!string.IsNullOrWhiteSpace(pet))
            {
                Models.ServiceResponse svcResponse = await _svcHelper.GetServiceResponseAsync(Utility.BaseDomainUrl, Utility.PeopleServiceUri);

                if (svcResponse.StatusCode == StatusCodeValues.SUCCESS)
                {
                    List<Models.OwnerDetail> lstOwnerDetails = Utility.GetObjectFromJson<List<Models.OwnerDetail>>(svcResponse.Output);
                    sortedViewModel.GenderWiseNames = _dprocessor.SortByPetType(lstOwnerDetails, pet);
                    sortedViewModel.StatusCode = StatusCodeValues.SUCCESS;
                    sortedViewModel.StatusMessage = Constants.SUCCESS_TEXT_MSG;
                }
                else
                {
                    sortedViewModel.StatusCode = StatusCodeValues.SERVICE_CALL_ERROR;
                    sortedViewModel.StatusMessage = Constants.GET_DATA_ERROR_MSG;
                }
            }

            return View(sortedViewModel);
        }

    }
}