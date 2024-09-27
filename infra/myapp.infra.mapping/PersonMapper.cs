namespace myapp.infra.mapping;

public class PersonMapper
{
    
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetFullName()))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));

            CreateMap<PersonQuery, Person>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Name)) // Assuming Name from query is the full name
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => 0)); // Assuming age is not provided in query
        }
    }
}