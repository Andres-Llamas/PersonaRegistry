using PersonaRegistry.Elements.Persona;
using PersonaRegistry.Interfaces.Persona;

namespace PersonaRegistry.DTOs.Persona
{
    public class PersonaDto : IPersona
    {
        public string? Name { get; set; }
        public PersonaArcana Arcana { get; set; }
        public int BaseLevel { get; set; }
        public PersonaStatsDto Stats { get; set; }
        public Dictionary<Affinity, AffinityEffect>? StrongAffinities { get; set; }
        public List<Affinity>? WeakAffinities { get; set; }
        public string? BackgroundLore { get; set; }

        public PersonaDto() { this.Stats = new PersonaStatsDto(); }
    }
}