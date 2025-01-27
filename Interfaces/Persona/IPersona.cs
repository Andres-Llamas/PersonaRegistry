using PersonaRegistry.Elements.Persona;

namespace PersonaRegistry.Interfaces.Persona
{
    public interface IPersona : ICreature
    {
        public string? Name { get; set; }
        public PersonaArcana Arcana { get; set; }
        public int BaseLevel { get; set; }        
        public Dictionary<Affinity, AffinityEffect>? StrongAffinities { get; set; }
        public List<Affinity>? WeakAffinities { get; set; }
        public string? BackgroundLore { get; set; }
    }
}