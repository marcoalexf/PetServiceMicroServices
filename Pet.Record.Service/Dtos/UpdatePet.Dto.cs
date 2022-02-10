using System.ComponentModel.DataAnnotations;
using Pet.Record.Service.Enums;

namespace Pet.Record.Service.Dtos
{
    public record UpdatePetDto : IPetDto
    {
        [Required]
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Breed { get; init; }
        public string Color { get; init; }
        public Guid GuardianId { get; init; }
        public GENDER_ENUM Gender { get; init; }
    }
}