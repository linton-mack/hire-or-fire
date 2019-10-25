using System;
using System.Net.Http;
using HireOrFire.Model;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace HireOrFire.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class ApplicantsController : ControllerBase {

        private IDataStore myData;

        public ApplicantsController (IDataStore dataStore) {
            myData = dataStore;
        }

        [HttpGet ("all")]
        public JsonResult GetAllApplicants () {
            return new JsonResult (myData.Applicants);
        }

        [HttpGet ("hiredall")]
        public JsonResult GetAllHiredApplicants () {
            return new JsonResult (myData.HiredApplicants);
        }
        
        [HttpPost ("/hired")]
        public IActionResult PostApplicantToHired ([FromBody]ApplicantsDto hiredApplicant) {
            ApplicantsDto applicantHired = myData.AddNewHiredApplicant(hiredApplicant);
            if(ModelState.IsValid)
            {
                return CreatedAtAction(nameof(GetApplicantById), applicantHired);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetApplicantById(string id)
        {
            var applicant = myData.GetApplicantById(id);
            if (applicant != null)
            {
                return Ok(applicant);
            }
            else
            {
                return NotFound();
            }
        }

    }
}