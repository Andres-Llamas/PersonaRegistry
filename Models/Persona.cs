using PersonaRegistry.Elements.Persona;
using PersonaRegistry.Interfaces.PersonaInterfaces;

namespace PersonaRegistry.Models
{
    public class Persona : IPersona
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public PersonaArcana Arcana { get; set; }
        public int BaseLevel { get; set; }
        public IPersonaStats Stats { get; set; }
        public Dictionary<Affinity, AffinityEffect>? StrongAffinities { get; set; }
        public ICollection<Affinity>? WeakAffinities { get; set; }
        public string? BackgroundLore { get; set; }
    }
}