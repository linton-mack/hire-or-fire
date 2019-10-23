using System.Net.Http;
using HireOrFire.Model;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace HireOrFire.Controllers
{
    [Route("applicants")]
    public class ApplicantsController : Controller
    {

        private IDataStore myData;

        public ApplicantsController(IDataStore dataStore)
        {
            myData = dataStore;
        }
        
        [HttpGet("all")]
        public JsonResult GetAllApplicants()
        {
            return new JsonResult(myData.Applicants);
        }
        
        
    }
}