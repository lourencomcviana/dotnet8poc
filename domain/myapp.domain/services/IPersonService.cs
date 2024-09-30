using myapp.domain.models;

namespace myapp.domain.services;

public interface IPersonService
{
    public Task Save(Person person);
    
    public Task Delete(Person person);

    public Task<Person?> Get(string cpf);
    
    public Task<List<Person>> Filter(string name);
    
    
    
}