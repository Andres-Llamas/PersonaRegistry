using PersonaRegistry.DTOs.Persona;
using PersonaRegistry.Models;

namespace PersonaRegistry.Interfaces.Persona
{
    public interface IPersonaService
    {
        public ICollection<Models.Persona> GetAll();
        public Models.Persona? GetById(Guid id);
        public Models.Persona? Create(CreatePersonaDto newPersona);
        public Models.Persona? Update(Guid id, Models.Persona updatedPersona);
        public void Delete(Guid id);
    }
}