using System.Collections.Generic;
using System.Linq;

namespace HireOrFire.Model
{
    public class DataStore : IDataStore
    {
        public List<ApplicantsDto> Applicants { get; }
        public List<ApplicantsDto> HiredApplicants { get; }

        public ApplicantsDto AddNewHiredApplicant(ApplicantsDto hiredApplicant)
        {
            ApplicantsDto applicantToAdd = new ApplicantsDto(hiredApplicant.Id, hiredApplicant.Name, hiredApplicant.Hired, hiredApplicant.Skip);
            HiredApplicants.Add(applicantToAdd);
            return applicantToAdd;
        }

        public ApplicantsDto GetApplicantById(string id)
        {
            return Applicants.FirstOrDefault((applicant) => applicant.Id ==  id);
        }

        public DataStore()
        {
            Applicants = new List<ApplicantsDto>
            {
                new ApplicantsDto("1", "Jim", false, false),
                new ApplicantsDto("2", "Linton", false, false)
            };

            HiredApplicants = new List<ApplicantsDto>()
            {
                new ApplicantsDto("1", "Polly", true, false),
                new ApplicantsDto("2", "Petunia", true, false)
            };
        }
    }
}