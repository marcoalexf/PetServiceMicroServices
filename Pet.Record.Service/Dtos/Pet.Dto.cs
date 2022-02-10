using Pet.Record.Service.Enums;

namespace Pet.Record.Service.Dtos
{
    public record PetDto : IPetDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public PET_SPECIES Species { get; init; }
        public string Breed { get; init; }
        public string Color { get; init; }
        public Guid GuardianId { get; init; }
        public GENDER_ENUM Gender { get; init; }
        public Guid VaccinationPlanId { get; init; }
        public DateTime Birthday { get; init; }
    }
}