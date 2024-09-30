using AutoMapper;
using myapp.@interface.api.resources;
using Person = myapp.domain.models.Person;


namespace myapp.@interface.api.mappings;

public class PersonMapper
{
    
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonBody, Person>()
                .ConstructUsing(src => NewPerson(src));

            
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