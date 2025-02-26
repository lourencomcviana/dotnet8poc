using AutoMapper;
using myapp.business.Commands;
using myapp.domain.models;

namespace myapp.business.mappings;

public class CreateUserToPerson: Profile
{
    public CreateUserToPerson()
    {
        CreateMap<CreateUserCommand, Person>();
    }
}