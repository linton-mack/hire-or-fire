using System.Collections.Generic;

namespace HireOrFire.Model
{
    public interface IDataStore
    {
        List<ApplicantsDto> Applicants { get; }
        List<ApplicantsDto> HiredApplicants { get; }


        ApplicantsDto AddNewHiredApplicant(ApplicantsDto hiredApplicant);

        ApplicantsDto GetApplicantById(string id);
    }
    
}