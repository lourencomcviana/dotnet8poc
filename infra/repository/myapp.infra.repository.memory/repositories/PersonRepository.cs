using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myapp.domain.models;
using myapp.domain.repositories;
using myapp.infra.repository.memory.entities;

namespace myapp.infra.repository.memory.repositories;

public class PersonRepository(AppDbContext context,IMapper mapper) : IPersonRepository
{
    public async Task Save(Person person)
    {
        var personEntity = mapper.Map<PersonEntity>(person);
        context.Persons.Add(personEntity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Person person)
    {
        var personEntity = await GetEntity(person.Cpf);
        context.Persons.Remove(personEntity);
        await context.SaveChangesAsync();
    }

    public async Task<Person?> Get(string cpf)
    {
        var personEntity =  await GetEntity(cpf);
        return personEntity != null  ? mapper.Map<Person>(personEntity) : null;
    }

    public async Task<IEnumerable<Person>> Filter(string name)
    {
       return await context.Persons
            .Where(item => item != null && item.Name.ToLower().Contains(name.ToLower()))
            .Select(item => mapper.Map<Person>(item))
            .ToListAsync();
    }
    
    private async Task<PersonEntity?> GetEntity(string cpf)
    {
        return await context.Persons.FirstOrDefaultAsync(p => p != null && p.Cpf == cpf);

    }
}