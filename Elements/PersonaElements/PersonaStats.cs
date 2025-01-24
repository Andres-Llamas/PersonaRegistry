using PersonaRegistry.Interfaces.PersonaInterfaces;

namespace PersonaRegistry.Elements.Persona
{
    public struct PersonaStats : IPersonaStats
    {
        public int BaseHp { get; set; }
        public int BaseStrength { get; set; }
        public int BaseMagic { get; set; }
        public int BaseEndurance { get; set; }
        public int BaseAgility { get; set; }
        public int BaseLuck { get; set; }

        public PersonaStats(int baseHp, int baseStr, int baseMag, int baseEndu, int baseAgui, int baseLck)
        {
            this.BaseHp = baseHp;
            this.BaseStrength = baseStr;
            this.BaseMagic = baseMag;
            this.BaseEndurance = baseEndu;
            this.BaseAgility = baseAgui;
            this.BaseLuck = baseLck;
        }
    }
}