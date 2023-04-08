using Identity;
using Identity.Country;
using Identity.Gender;
using Identity.Generation;
using Identity.Services.Identity;
using Microsoft.OpenApi.Models;
using Refit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRefitClient<IAgifyClient>()
    .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://api.agify.io/"));
builder.Services.AddRefitClient<IGenderizeClient>()
    .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://api.genderize.io/"));
builder.Services.AddRefitClient<INationalizeClient>()
    .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://api.nationalize.io/"));

builder.Services.AddScoped<IGenerationFactory, GenerationFactory>();

builder.Services.AddSwaggerGen(options =>
{
    // Add header documentation in swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Identity API",
        Version = "v1",
        Description = "Randomized your identity using only your name!",
        Contact = new OpenApiContact
        {
            Name = "Group 3 - The Github Repository Link!",
            Url = new Uri("https://github.com/CITUCCS/csit340-final-project-group_3_theterminals")
        }
    });

    // Feed generated xml api docs to swagger
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

ConfigureServices(builder.Services);

// Inject Services
void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IIdentityService, IdentityService>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();  

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
