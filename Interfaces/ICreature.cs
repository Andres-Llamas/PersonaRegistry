namespace PersonaRegistry.Interfaces
{
    // In the future I'm planning to add more creatures like demons from SMT in addition to the personas
    // So the base will be ICreatures
    public interface ICreature
    {
        public string? Name { get; set; }
        public int BaseLevel { get; set; }

    }
}