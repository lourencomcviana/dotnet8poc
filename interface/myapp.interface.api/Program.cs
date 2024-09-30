
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myapp.domain.models;
using myapp.domain.services;
using myapp.infra.bootstrap;
using myapp.@interface.api.resources;
using Person = myapp.domain.models.Person;

var builder = WebApplication.CreateBuilder(args);

#region Custom Injections

// BootStrap service injection
builder.Services.ConfigureServices();

// Add Mapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

#endregion

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

# region API


app.MapPost("persons", async (Person person,
        [FromServices] IMapper mapper, 
        [FromServices] IPersonService personService
        ) => {
    await personService.Save(mapper.Map<Person>(person));
    return;
})
.WithName("PostPerson")
.WithOpenApi();;


app.MapGet("/api/person/{cpf}", async (string cpf, [FromServices] IMapper mapper, [FromServices] IPersonService personService) =>
{
    var person = await personService.Get(cpf);
    if (person == null)
    {
        return Results.NotFound("Person not found.");
    }

    var response = mapper.Map<PersonResponse>(person);
    return Results.Ok(response);
});
# endregion

# region DEMO
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

#endregion

app.Run();

