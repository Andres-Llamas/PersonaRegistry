namespace PersonaRegistry.Interfaces.Persona
{
    public interface IStats
    {
        public int BaseHp { get; set; }
        public int BaseStrength { get; set; }
        public int BaseMagic { get; set; }
        public int BaseEndurance { get; set; }
        public int BaseAgility { get; set; }
        public int BaseLuck { get; set; }
    }
}