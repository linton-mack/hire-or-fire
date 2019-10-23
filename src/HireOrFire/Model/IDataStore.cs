using System.Collections.Generic;

namespace HireOrFire.Model
{
    public interface IDataStore
    {
        List<ApplicantsDto> Applicants { get; }
        
    }
}