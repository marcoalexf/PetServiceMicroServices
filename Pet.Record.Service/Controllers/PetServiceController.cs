using Microsoft.AspNetCore.Mvc;
using Pet.Record.Service.Dtos;
using Pet.Record.Service.Entities;
using Pet.Record.Service.Enums;
using Pet.Record.Service.Extensions;

namespace Pet.Record.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class PetServiceController : ControllerBase
{
    private readonly ILogger<PetServiceController> _logger;
    private List<PetEntity> _pets = new List<PetEntity>()
    {
        new PetEntity
        {
            Id = Guid.NewGuid(),
            Name = "Bobby",
            Species = PET_SPECIES.DOG,
            Breed = "Labrador",
            Color = "Black",
            GuardianId = Guid.NewGuid(),
            Birthday = DateTime.Now,
        }
    };

    public PetServiceController(ILogger<PetServiceController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPet")]
    public ActionResult<PetDto> GetPetById(Guid id)
    {

        _logger.LogInformation($"GetPetById: {id}");
        var pet = _pets.FirstOrDefault(p => p.Id == id);

        if (pet is not null)
        {
            _logger.LogInformation($"Pet found: {pet.Name}. ID: {pet.Id}");
            return Ok(pet.ToDto());
        }

        _logger.LogInformation($"Pet not found: {id}");
        return NotFound();
    }

    [HttpGet(Name = "GetPets")]
    public ActionResult<List<PetDto>> GetPets()
    {
        return Ok(_pets.Select(p => p.ToDto()).ToList());
    }

    [HttpPost(Name = "CreatePet")]
    public IActionResult CreatePet(CreatePetDto createPetDto)
    {
        _logger.LogInformation($"Creating pet. Transforming {createPetDto.ToString()} to {nameof(PetEntity)}");
        var pet = createPetDto.ToEntity();
        _logger.LogInformation($"Created pet with id {pet.Id}, name {createPetDto.Name}, species {createPetDto.Species}, breed {createPetDto.Breed}");
        this._pets.Add(pet);

        // TODO: Implement repository
        return CreatedAtAction(nameof(GetPetById), new { id = pet.Id }, pet);
    }

    [HttpPut(Name = "UpdatePet")]
    public IActionResult UpdatePet(UpdatePetDto updatePetDto)
    {
        _logger.LogInformation($"Updating pet with id {updatePetDto.Id}");
        var petToUpdate = _pets.FirstOrDefault(p => p.Id == updatePetDto.Id);
        if (petToUpdate is not null)
        {
            _logger.LogInformation($"Pet with id {updatePetDto.Id} found, updating.");
            var updatedPet = petToUpdate with
            {
                Name = updatePetDto.Name,
                Breed = updatePetDto.Breed,
                Color = updatePetDto.Color,
                GuardianId = updatePetDto.GuardianId,
            };

            // Update pet in _pets collection
            _pets.Where(p => p.Id == updatePetDto.Id).Select(p => p = updatedPet);

            return AcceptedAtAction(nameof(GetPetById), new { id = updatedPet.Id }, updatedPet);
        }
        else
        {
            _logger.LogInformation($"Pet with id {updatePetDto.Id} not found.");
            return NotFound();
        }
    }

    [HttpDelete(Name = "DeletePet")]
    public IActionResult DeletePet(Guid id)
    {
        _logger.LogInformation($"Received DELETE request for Pet with id {id}");
        var petToDelete = _pets.FirstOrDefault(p => p.Id == id);
        if (petToDelete is not null)
        {
            _logger.LogInformation($"Deleting Pet with id {id}");
            _pets.Remove(petToDelete);
            return Ok();
        }
        else
        {
            _logger.LogInformation($"Pet with id {id} not found");
            return NotFound();
        }
    }
}
