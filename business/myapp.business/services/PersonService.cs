using Microsoft.Extensions.Logging;
using myapp.domain.models;
using myapp.domain.repositories;
using myapp.domain.services;

namespace myapp.business.services;

public class PersonService(
    ILogger<PersonService> log, 
    IPersonRepository repository) : IPersonService
{
    public async Task Save(Person person)
    {
        await repository.Save(person);
        log.LogInformation("tryed to save person {}", person);
    }

    public async Task Delete(Person person)
    {
        throw new NotImplementedException();
    }

    public async Task<Person?> Get(string cpf)
    {
        return await repository.Get(cpf);
    }

    public async Task <IEnumerable<Person>> Filter(string name)
    {
        throw new NotImplementedException();
    }
}

