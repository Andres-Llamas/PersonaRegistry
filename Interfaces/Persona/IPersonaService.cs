using PersonaRegistry.DTOs.PersonaDTOs;
using PersonaRegistry.Models;

namespace PersonaRegistry.Interfaces.PersonaInterfaces
{
    public interface IPersonaService
    {
        public ICollection<Persona> GetAll();
        public Persona? GetById(Guid id);
        public Persona? Create(CreatePersonaDto newPersona);
        public Persona? Update(Guid id, Persona updatedPersona);
        public void Delete(Guid id);
    }
}