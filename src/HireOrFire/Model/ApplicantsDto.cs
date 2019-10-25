using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HireOrFire.Model
{
    public class ApplicantsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Hired { get; set; }
        public bool Skip { get; set; }

        public ApplicantsDto(string id, string name, bool hired, bool skip)
        {
            Id = id;
            Name = name;
            Hired = hired;
            Skip = skip;
        }

        public ApplicantsDto() { }

        public static void writeToFile(ApplicantsDto applicant)
        {
            try
            {
                var data = JsonConvert.SerializeObject(applicant);
                File.WriteAllText("/Users/jimhiggins/academy/Code/northCodersC#/hire-or-fire/src/HireOrFire/Model/JsonData/data.json", data);
            }
            catch (Exception e)
            {
                Console.WriteLine("-------------ERROR---------------");
                Console.WriteLine(applicant.Name);
                Console.WriteLine(JsonConvert.SerializeObject(applicant));
            }
        }
    }
}