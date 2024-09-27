using myapp.domain.models;

namespace myapp.domain.services;

public interface IPersonService
{
    public void save(Person person);

    public Person get(String name);

}