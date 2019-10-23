using System.Collections.Generic;

namespace HireOrFire.Model
{
    public class DataStore : IDataStore
    {
        public List<ApplicantsDto> Applicants { get; }

        public DataStore()
        {
            Applicants = new List<ApplicantsDto>
            {
                new ApplicantsDto("1", "Jim", false, false),
                new ApplicantsDto("2", "Linton", false, false)
            };
        }
    }
}