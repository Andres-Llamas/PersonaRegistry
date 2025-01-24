using PersonaRegistry.Elements.Persona;

namespace PersonaRegistry.Interfaces.PersonaInterfaces
{
    public interface IPersona
    {
        public string? Name { get; set; }
        public PersonaArcana Arcana { get; set; }
        public int BaseLevel { get; set; }        
        public Dictionary<Affinity, AffinityEffect>? StrongAffinities { get; set; }
        public ICollection<Affinity>? WeakAffinities { get; set; }
        public string? BackgroundLore { get; set; }
    }
}