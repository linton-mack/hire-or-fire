namespace HireOrFire.Model
{
    public class ApplicantsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ApplicantsDto(string id, string name)
        {
            Id = id;
            Name = name;
        }
        
        
    }
}