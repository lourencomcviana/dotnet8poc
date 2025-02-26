
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using AutoMapper;
using CsvHelper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using myapp.application.api.Controllers;
using myapp.domain.models;
using myapp.domain.services;
using myapp.infra.bootstrap;
using myapp.@application.api.resources;
using myapp.business.Commands;
using myapp.util.exceptions;
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

app.MapPost("persons", async (HttpRequest request,
    [FromServices] IMapper mapper,
    [FromServices] IPersonService personService,
    [FromServices] IMediator mediator) =>
{
    try
    {
        if (request.ContentType == "application/json")
        {
            // Handle JSON input
            var person = await request.ReadFromJsonAsync<PersonBody>();
            var res = await mediator.Send(mapper.Map<CreateUserCommand>(person));
            return Results.Ok(res);
        }
        
        if (request.ContentType == "text/csv")
        {
            // Handle CSV input
            IEnumerable<PersonBody> records;
            using var reader = new StreamReader(request.Body);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var content = await reader.ReadToEndAsync();
            
            using var stringReader = new StringReader(content);
            
            var newReader = new CsvReader(stringReader, csv.Context.Configuration);
            records = newReader.GetRecords<PersonBody>().ToList();
                
                
            var tasks = records.Select(async person =>
            {
                var res = await mediator.Send(mapper.Map<CreateUserCommand>(person));
                return res;
            });

            var results = await Task.WhenAll(tasks);
            return Results.Ok((object?)results);
        }
        
        return Results.Problem("Unsupported Content-Type", statusCode: 415);
        
    }
    catch (HttpException e)
    {
        return Results.Problem(e.Message, statusCode: e.HttpCode);
    }
})
.WithName("PostPerson")
.WithTags("Persons")
.WithOpenApi(op =>
{
    op.OperationId = "PostPerson";
    op.RequestBody = new Microsoft.OpenApi.Models.OpenApiRequestBody
    {
        Content =
        {
            ["application/json"] = new Microsoft.OpenApi.Models.OpenApiMediaType
            {
                Schema = new Microsoft.OpenApi.Models.OpenApiSchema
                {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
                    {
                        Type = Microsoft.OpenApi.Models.ReferenceType.Schema,
                        Id = "PersonBody"
                    }
                },
                Example = new Microsoft.OpenApi.Any.OpenApiObject
                {
                    ["name"] = new Microsoft.OpenApi.Any.OpenApiString("John Doe"),
                    ["age"] = new Microsoft.OpenApi.Any.OpenApiInteger(30)
                }
            },
            ["text/csv"] = new Microsoft.OpenApi.Models.OpenApiMediaType
            {
                Schema = new Microsoft.OpenApi.Models.OpenApiSchema
                {
                    Type = "string",
                    Format = "string"
                },
                Example = new Microsoft.OpenApi.Any.OpenApiString("name,age\nJohn Doe,30")
            }
        }
    };
    return op;
});



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

