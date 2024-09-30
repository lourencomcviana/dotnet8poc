using AutoMapper;
using myapp.infra.repository.memory.entity;
using Person = myapp.domain.models.Person;

namespace myapp.infra.repository.memory.mappings;

public class PersonMapper
{
    
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {

            // Map Person to PersonEntity
            CreateMap<Person, PersonEntity>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName));
            
                
            // Map PersonEntity to Person
            CreateMap<PersonEntity, Person>()
                .ConstructUsing(src => NewPerson(src));
        }
        
        private Person NewPerson(PersonEntity src)
        {
            return new Person(
                Name: src.FirstName,
                Surname: src.LastName,
                Cpf: src.Cpf,
                Age: src.Age
            );
        }
    }

    
    
    
}