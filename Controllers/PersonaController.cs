using Microsoft.AspNetCore.Mvc;
using PersonaRegistry.DTOs.PersonaDTOs;
using PersonaRegistry.Interfaces.PersonaInterfaces;
using PersonaRegistry.Models;

namespace PersonaRegistry.Controllers
{
    [Controller]
    [Route("api/v1/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            this._personaService = personaService;
        }

        [HttpGet]
        public ActionResult<List<Persona>> GetAll()
        {
            return Ok(_personaService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Persona> GetById(Guid id)
        {
            Persona persona = _personaService.GetById(id);
            if (persona is null) return NotFound();
            return Ok(persona);
        }

        [HttpPost]
        public ActionResult Create([FromBody]CreatePersonaDto personaToCreate)
        {
            var createdPersona = _personaService.Create(personaToCreate);
            if (createdPersona is null) return BadRequest();

            /*
               Created at route generates two things
            %  A 201 http response    
            &  A Location header in the response, pointing to a resource's URL (e.g., /persona/{id}).
            ~  new { id = game.Id } is an anonymous object, meaning it's temporary and don't need to be a specific class type
            ~  The route in this case, /persona/{id}, expects an id parameter. CreatedAtRoute passes such parameter from objects,
            ~  so we creates an anonymous object with the parameters CreatedAtRoute will pass to display the route where the resource
            ~  has been created

            */
            return CreatedAtAction(nameof(GetById), new { id = createdPersona.Id }, createdPersona);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, Persona updatedPersona)
        {
            var existingPersona = _personaService.GetById(id);
            if(existingPersona is null) return NotFound();
            _personaService.Update(id, updatedPersona);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var existingPersona = _personaService.GetById(id);
            if(existingPersona is null) return NotFound();
            _personaService.Delete(id);
            return NoContent();
        }
    }
}