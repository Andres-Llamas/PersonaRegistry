using Microsoft.EntityFrameworkCore;
using PersonaRegistry.Models;

namespace PersonaRegistry.Contexts
{
    /// <summary>
    /// This class provides the connection between the app and the database
    /// To allow operations between the entities (tables)
    /// </summary>

    // DbContext is the class from EF responsible for all the behaviors necessary to interact with the 
    // database like querying, saving, configuration, etc
    public class PersonaContext : DbContext
    {
        // A DbSet<T> represents a table in the database
        public DbSet<Persona> Personas { get; set; }

        // !Constructor explanation
        /*              
        *   This constructor takes one argument of type DbContextOptions<T>.            
        \% The argument DbContextOptions<T> is an object meant to be used for configuration provided by the Entity framework core
        %  It contains the settings needed to connect and configure the data base
        %  such as the database provider, the connection string which specifies where the data base is hosted, among other settings

        \& Then, the argument is passed as a parameter to the base constructor
        &  It calls the base constructor and passes the settings object as a parameter so that the base class uses the options in the
        &  DbContextOptions object to perform it's own initialization

        @  In this case, the context class (PersonaContext) do not use the DbContextOptions, but it ensures that is passed to the 
        @  base class (DbContext)
        */
        public PersonaContext(DbContextOptions<PersonaContext> options) : base(options) { }

        /*
            \$ the function is called when the database is being created
            $  This is where you define hot entities (c# classes) should be mapped to the database tables and columns
            $  This method allows configuration that can´t be done via attributes            
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder) // ModelBuilder object is the responsible for building a model and set up the configuration to be mapped to the database schema
        {
            //.Entity configures an specific entity type for ModelBuilder and returns an EntityTypeBuilder<T>
            modelBuilder.Entity<Persona>(persona =>// persona is an EntityTypeBuilder<T> where <T> is Persona. This object provides configuration methods which returns the same object so it could be chained
            {
                persona.ToTable("Persona"); // maps the Persona class to a table named Persona in database. If omitted, the table is named after the class

                // The parameter p is a Persona instance passed as a parameter by the EntityTypeBuilder<Category>
                /*
                \~  The lambda function is not called by HasKey as you'd normally think
                ~    Instead of call it as callback(Category c) and check its return value (in this case c.Id), EF "Analyzes the"
                ~    lambda as an expression tree. making something similar as this
                ~            LambdaExpression: c => c.Id
                ~               - Parameter: c (Category)
                ~               - MemberAccess: Id
                ~   EF figures out who is parameter and who is property and then, in this case, sets up the property (Id) as the primary key
                ~   This is done so that EF doesn't need to care what is the type of the property or force you to use a specific type for the property
                ~   Since it is not taking into account the returned value but rather analyzing who is the property to be used in config, we avoid doing 
                ~   stuff like using strings as the name of parameter such as " HasKey("Id")) "
                */
                persona.HasKey(p => p.Id);// Set Category's Id property as the primary key
                persona.Property(p => p.Name).IsRequired().HasMaxLength(60);
                persona.Property(p => p.BackgroundLore).HasMaxLength(300);
                persona.Property(p => p.Arcana);
                persona.Property(p => p.BaseLevel);
                persona.OwnsOne(p=> p.Stats);
                persona.OwnsOne(p => p.StrongAffinities);
                persona.Property(p => p.WeakAffinities);
            });
        }
    }
}