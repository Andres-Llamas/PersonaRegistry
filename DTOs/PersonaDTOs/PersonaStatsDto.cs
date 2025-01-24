using PersonaRegistry.Interfaces.PersonaInterfaces;

namespace PersonaRegistry.DTOs.PersonaDTOs
{
    public record class PersonaStatsDto : IPersonaStats
    {
        public int BaseHp { get; set; }
        public int BaseStrength { get; set; }
        public int BaseMagic { get; set; }
        public int BaseEndurance { get; set; }
        public int BaseAgility { get; set; }
        public int BaseLuck { get; set; }
    }
}