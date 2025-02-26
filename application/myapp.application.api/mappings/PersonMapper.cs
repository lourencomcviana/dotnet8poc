using AutoMapper;
using myapp.@application.api.resources;
using myapp.business.Commands;
using Person = myapp.domain.models.Person;

namespace myapp.@application.api.mappings;

public class PersonMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonBody, Person>()
                .ConstructUsing(src => NewPerson(src));
            
            
            CreateMap<PersonBody, CreateUserCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
            ;
            
            CreateMap<Person, PersonResponse>()
                .ConstructUsing(src => NewPersonResponse(src));

            CreateMap<PersonQuery, Person>()
                .ConstructUsing(src => NewPerson(src));
        }
        
        private PersonResponse NewPersonResponse(Person src)
        {
            return new PersonResponse(
                Name: src.FullName,
                Cpf: src.Cpf,
                Age: src.Age
            );
        }
        
        private Person NewPerson(PersonBody src)
        {
            return new Person(
                Name: src.FirstName,
                Surname: src.LastName,
                Cpf: src.Cpf,
                Age: src.Age
            );
        }
        
        private Person NewPerson(PersonQuery src)
        {
            return new Person(
                Name: src.Name,
                Surname: "",
                Cpf: src.Cpf,
                Age: 0
            );
        }
    }
}