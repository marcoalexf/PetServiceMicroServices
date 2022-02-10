using Pet.Record.Service.Enums;

namespace Pet.Record.Service.Entities
{
    public record PetEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PET_SPECIES Species { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public Guid GuardianId { get; set; }
        public GENDER_ENUM Gender { get; set; }
        public Guid VaccinationPlanId { get; set; }
        public DateTime Birthday { get; set; }
    }
}