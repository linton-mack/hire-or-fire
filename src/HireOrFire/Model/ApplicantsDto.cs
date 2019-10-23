namespace HireOrFire.Model {
    public class ApplicantsDto {
        public string Id { get; set; }
        public string Name { get; set; }

        public bool Hired { get; set; }

        public ApplicantsDto (string id, string name, bool yar) {
            Id = id;
            Name = name;
            Hired = yar;
        }

    }
}