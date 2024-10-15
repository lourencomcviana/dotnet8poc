
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myapp.application.api.Controllers;
using myapp.domain.models;
using myapp.domain.services;
using myapp.infra.bootstrap;
using myapp.@application.api.resources;
using Person = myapp.domain.models.Person;

var builder = WebApplication.CreateBuilder(args);

// // Configuration Sources
// builder.Configuration
//     .SetBasePath(Directory.GetCurrentDirectory())
//     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//     .AddEnvironmentVariables()
//     .AddCommandLine(args);

#region Custom Injections
// BootStrap service injection
builder.Services.ConfigureServices(builder.Configuration);

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
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

# region API


app.MapPost("persons", async (PersonBody person,
        [FromServices] IMapper mapper, 
        [FromServices] IPersonService personService
        ) => {
    await personService.Save(mapper.Map<Person>(person));
    return;
})
.WithName("PostPerson")
.WithTags("Persons")
.WithOpenApi();


app.MapGet("persons/{cpf}", async (string cpf, [FromServices] IMapper mapper, [FromServices] IPersonService personService) =>
{
    var person = await personService.Get(cpf);
    if (person == null)
    {
        return Results.NotFound("Person not found.");
    }

    var response = mapper.Map<PersonResponse>(person);
    return Results.Ok(response);
})
.WithName("GetPerson")
.WithTags("Persons")
.WithOpenApi();

# endregion

# region DEMO

app.MapWeatherApi();

#endregion

app.Run();

