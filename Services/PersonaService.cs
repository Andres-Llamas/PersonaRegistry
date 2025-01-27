using PersonaRegistry.Models;
using PersonaRegistry.Interfaces.Persona;
using PersonaRegistry.DTOs.Persona;
using PersonaRegistry.Elements.Persona;

namespace PersonaRegistry.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly List<Persona> PersonasDataBase; // Replace for Postgresql later

        public PersonaService()
        {
            this.PersonasDataBase = new List<Persona>();
            PersonasDataBase.Add(new Persona());
            Persona persona = PersonasDataBase[0];
            persona.Id = Guid.NewGuid();
            persona.Name = "Arsène";
            persona.Arcana = PersonaArcana.Fool;
            persona.BaseLevel = 1;
            persona.Stats = new PersonaStats(-1, 2, 2, 2, 3, 1);
            persona.WeakAffinities = [Affinity.Ice, Affinity.Bless];
            persona.StrongAffinities = new Dictionary<Affinity, AffinityEffect> { { Affinity.Course, AffinityEffect.Resist } };
            persona.BackgroundLore = "A being based off the main character of Maurice Leblanc's novels, Arsène Lupin. He appears everywhere and is a master of disguise. He is known to help law-abiding citizens.";

            PersonasDataBase.Add(new Persona());
            persona = PersonasDataBase[1];
            persona.Id = Guid.NewGuid();
            persona.Name = "Pixie";
            persona.Arcana = PersonaArcana.Lovers;
            persona.BaseLevel = 2;
            persona.Stats = new PersonaStats(-1, 1, 3, 3, 4, 3);
            persona.WeakAffinities = [Affinity.Gunfire, Affinity.Ice, Affinity.Course];
            persona.StrongAffinities = new Dictionary<Affinity, AffinityEffect> { { Affinity.Electric, AffinityEffect.Resist }, { Affinity.Bless, AffinityEffect.Resist } };
            persona.BackgroundLore = "Friendly fairies of the forest that tend to hide from humans. They like to play tricks on the Laz sic people. It is said they are the souls of dead, unbaptized children.";
        }

        public ICollection<Persona> GetAll()
        {
            return PersonasDataBase;
        }

        public Persona? GetById(Guid id)
        {
            var personaToReturn = PersonasDataBase.Find(p => p.Id == id);
            return personaToReturn;
        }

        public Persona? Create(CreatePersonaDto newPersona)
        {
            Persona createdPersona = new Persona();            
            if (newPersona is null)
            {
                // print on log persona is null
                return null;
            }
            try
            {
                createdPersona.Id = Guid.NewGuid();
                createdPersona.Name = newPersona.Name;
                createdPersona.Arcana = newPersona.Arcana;
                createdPersona.BackgroundLore = newPersona.BackgroundLore;
                createdPersona.BaseLevel = newPersona.BaseLevel;
                createdPersona.Stats = newPersona.Stats;
                createdPersona.StrongAffinities = newPersona.StrongAffinities;
                createdPersona.WeakAffinities = newPersona.WeakAffinities;

                PersonasDataBase.Add(createdPersona);
            }
            catch (Exception e)
            {
                //log error 
            }

            return createdPersona;
        }

        public Persona? Update(Guid id, Persona updatedPersona)
        {
            int indexOfPersonaToUpdate = PersonasDataBase.FindIndex(p => p.Id == id);
            Persona personaToUpdate = PersonasDataBase[indexOfPersonaToUpdate];

            if (personaToUpdate is null)
                return null;
            personaToUpdate.Name = updatedPersona.Name;
            personaToUpdate.Arcana = updatedPersona.Arcana;
            personaToUpdate.BackgroundLore = updatedPersona.BackgroundLore;
            personaToUpdate.BaseLevel = updatedPersona.BaseLevel;
            personaToUpdate.Stats = updatedPersona.Stats;
            personaToUpdate.StrongAffinities = updatedPersona.StrongAffinities;
            personaToUpdate.WeakAffinities = updatedPersona.WeakAffinities;

            return personaToUpdate;
        }

        public void Delete(Guid id)
        {
            var indexToDelete = PersonasDataBase.FindIndex(p => p.Id == id);
            if (indexToDelete != -1)
            {
                PersonasDataBase.Remove(PersonasDataBase[indexToDelete]);
            }
        }
    }
}