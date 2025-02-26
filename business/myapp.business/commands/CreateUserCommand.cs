using AutoMapper;
using MediatR;
using myapp.domain.models;
using myapp.domain.services;

namespace myapp.business.Commands;

public class CreateUserCommand: IRequest<Person>
{
    public string? Name { get; init; }
    public string? Surname { get; init; }
    public string? Cpf { get; init; }
    public int? Age { get; init; }
    
    public string Validation { get; set; }
}


public class CreateUserCommandHandler(IPersonService personService, IMapper mapper) : IRequestHandler<CreateUserCommand,Person>
{
  
    public async Task<Person> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var person = mapper.Map<Person>(request);
        await personService.Save(person);
        return person;
    }
}
