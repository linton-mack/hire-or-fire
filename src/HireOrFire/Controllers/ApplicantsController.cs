using System.Net.Http;
using HireOrFire.Model;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace HireOrFire.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class ApplicantsController : ControllerBase 
    {

        private IDataStore myData;

        public ApplicantsController (IDataStore dataStore) {
            myData = dataStore;
        }

        [HttpGet ("all")]
        public JsonResult GetAllApplicants () {
            return new JsonResult (myData.Applicants);
        }

    }
}