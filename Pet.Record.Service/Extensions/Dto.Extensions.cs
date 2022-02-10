using Pet.Record.Service.Dtos;
using Pet.Record.Service.Entities;

namespace Pet.Record.Service.Extensions
{
    public static class Extensions
    {
        public static PetEntity ToEntity(this CreatePetDto dto) => new PetEntity
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Species = dto.Species,
            Breed = dto.Breed,
            Color = dto.Color,
            GuardianId = dto.GuardianId,
            Birthday = dto.Birthday,
            Gender = dto.Gender,
            VaccinationPlanId = Guid.Empty,
        };

        public static PetDto ToDto(this PetEntity pet) => new PetDto
        {
            Id = pet.Id,
            Birthday = pet.Birthday,
            Breed = pet.Breed,
            Color = pet.Color,
            GuardianId = pet.GuardianId,
            VaccinationPlanId = pet.VaccinationPlanId,
            Gender = pet.Gender,
            Name = pet.Name,
            Species = pet.Species
        };
    }
}