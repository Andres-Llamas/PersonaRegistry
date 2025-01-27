using PersonaRegistry.Interfaces.Persona;
using PersonaRegistry.Services;
/*
    \%Starting point for the ASP.NET app
%     The "args" parameter is an array of command line arguments. similar to static void Main(string[] args)
%     This is so, when we use dotnet run, the arguments from the command line like --environment are passed to
%     the ASP.NET core framework to configure the application
*/
var builder = WebApplication.CreateBuilder(args);

/*
\&   builder.Services, Services is a property of the WebApplicationBuilderClass
&     The Services property provides access to the Service Collection
&     The Service Collection is a registry where you configure the application dependencies (following the Dependency Injection design pattern)
&     The registered services can then be provided (injected) into any part of the app
&     Dependency Injection is a design pattern that allows you to provide objects to classes that need them without hardcoding how those objects are created
~      .Services is a property of type IServiceCollection
\@   What is this line doing?
?     This line registers IPersonaService as a service (a dependency) in the DI container
?     This is like telling the DI. "When someone ask for a IPersonaService, you are going to give them an instance with this implementation (PersonService)
?     There are three ways to register services. Singleton, scoped, and transient
*/
builder.Services.AddSingleton<IPersonaService, PersonaService>();
builder.Services.AddControllers();

var app = builder.Build(); // Services should be added before builder.Build()

app.MapGet("/", () => "Welcome to Persona Registry");

app.UseRouting();
app.MapControllers();

app.Run();
