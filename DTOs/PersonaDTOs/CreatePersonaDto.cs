using PersonaRegistry.Elements.Persona;
using PersonaRegistry.Interfaces.PersonaInterfaces;

namespace PersonaRegistry.DTOs.PersonaDTOs
{
    public record class CreatePersonaDto : IPersona
    {
        public string? Name { get; set; }
        public PersonaArcana Arcana { get; set; }
        public int BaseLevel { get; set; }
        public PersonaStatsDto Stats { get; set; }
        public Dictionary<Affinity, AffinityEffect>? StrongAffinities { get; set; }
        public ICollection<Affinity>? WeakAffinities { get; set; }
        public string? BackgroundLore { get; set; }
    }
}