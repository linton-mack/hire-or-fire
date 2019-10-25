using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;

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
            return Applicants.FirstOrDefault((applicant) => applicant.Id == id);
        }

        public DataStore()
        {
            Applicants = new List<ApplicantsDto>
            {
                new ApplicantsDto("1", "Jim", false, false),
                new ApplicantsDto("2", "Linton", false, false)
            };

            HiredApplicants = new List<ApplicantsDto>{
       
            };
            // HiredApplicants = GenerateHiredApplicantsList();
        }

        public static List<ApplicantsDto> GenerateHiredApplicantsList()
        {
            List<ApplicantsDto> hiredAppList = new List<ApplicantsDto>();
            var rawText = File.ReadAllText("/Users/jimhiggins/academy/Code/northCodersC#/hire-or-fire/src/HireOrFire/Model/JsonData/data.json");
            var jsonArray = JArray.Parse(rawText);

            foreach (JObject obj in jsonArray.Children<JObject>())
            {
                dynamic mrdragon = JObject.Parse(obj.ToString());

                string id = mrdragon.Id;
                string name = mrdragon.Name;
                bool hired = mrdragon.Hired;
                bool skip = mrdragon.Skip;

                ApplicantsDto hiredApplicantToAdd = new ApplicantsDto(id, name, hired, skip);
                hiredAppList.Add(hiredApplicantToAdd);
            }
            return hiredAppList;
        }
    }
}