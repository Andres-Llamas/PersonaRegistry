using PersonaRegistry.Elements.Persona;
using PersonaRegistry.Interfaces.Persona;

namespace PersonaRegistry.Models
{
    public class Persona : IPersona
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public PersonaArcana Arcana { get; set; }
        public int BaseLevel { get; set; }
        public IStats Stats { get; set; }
        public Dictionary<Affinity, AffinityEffect>? StrongAffinities { get; set; }
        public List<Affinity>? WeakAffinities { get; set; }
        public string? BackgroundLore { get; set; }
    }
}