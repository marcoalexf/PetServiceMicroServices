using System.ComponentModel.DataAnnotations;
using Pet.Record.Service.Enums;

namespace Pet.Record.Service.Dtos
{
    public record CreatePetDto : IPetDto
    {

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Gender is required")]
        public GENDER_ENUM Gender { get; init; }

        [Range(0, int.MaxValue, ErrorMessage = "Age is in years, the minimum is 0")]
        public DateTime Birthday { get; init; }
        public Guid GuardianId { get; init; }

        [Required]
        public PET_SPECIES Species { get; init; }

        [Required]
        public string Breed { get; init; }
        public string Color { get; init; }
    }
}