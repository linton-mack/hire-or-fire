using Xunit;
using Moq;
using HireOrFire.Model;
using Microsoft.AspNetCore.Mvc;
using HireOrFire.Controllers;

namespace tests
{
    public class ApplicantsControllerTest
    {
        [Fact]
        public void GetApplicantsByID_Return200()
        {
            var mockRepo = new Mock<IDataStore>();
            ApplicantsDto mockApplicant = new ApplicantsDto("1", "Doddle", false, false);
            mockRepo.Setup((repo) => repo.GetApplicantById("1")).Returns(mockApplicant);
            var sut = new ApplicantsController(mockRepo.Object);

            IActionResult result = sut.GetApplicantById("1");

            Assert.IsType<OkObjectResult>(result);
        }

        // [Fact]
        // public void PostHiredApplicants(){
        //     var mockNewHiredApplicant = new ApplicantsDto("5","Doddle",true, false);
        //     var mockRepo = new Mock<IDataStore>();
        //     mockRepo.Setup((a) => a.AddNewHiredApplicant(mockNewHiredApplicant)).Returns(mockNewHiredApplicant);

        //     var sut = new ApplicantsController(mockRepo.Object);
        // }
    }
}
