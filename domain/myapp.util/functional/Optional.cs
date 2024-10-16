using System.Collections;

namespace myapp.util.functional;

/***
 * why? https://medium.com/@carlosbueno.kinder/implementing-functional-patterns-in-c-the-option-maybe-pattern-d1f97fb6f5ba
 * - Banish the risk of null values and null checks, making your code safer than ever.
 * - Embrace the functional way by treating values as immutable and using higher-order functions like a pro.
 * - Enhance your code’s readability and maintainability by making it clear when a value may or may not be present.
 * - Debug like a champ, catching potential errors related to missing values during compile-time, not runtime.
 */
public class Optional<T>
{
    private readonly T? _value;

    private Optional(T value)
    {
        _value = value;
    }

    private Optional()
    {
    }
    
    private T Value => _value ?? throw new InvalidOperationException();

    
    public static Optional<T> Of(T? value)
    {
        return Of(value, arg => true);
    }
    
    public static Optional<T> Of(T? value, Func<T, Boolean> validationProvider)
    {
        if (value == null  || !validationProvider.Invoke(value))
        {
            return Empty();
        }
        return new Optional<T>(value);
        
    }

    public static Optional<T> Empty()
    {
        return new Optional<T>();
    }

    public bool IsPresent() => _value != null;

    public void IfPresent(Action<T> action)
    {
        if (IsPresent())
        {
            action(Value);
        }
    }

    public Optional<TU> Map<TU>(Func<T, TU> mapper)
    {
        return IsPresent() ? Optional<TU>.Of(mapper(Value)) : Optional<TU>.Empty();
    }

    public T OrElse(T other) => _value != null ? _value : other;

    public T OrElseThrow<TE>(Func<TE> exceptionSupplier) where TE : Exception
    {
        if (IsPresent())
        {
            return Value;
        }

        throw exceptionSupplier();
    }

    public T Get()
    {
        if (!IsPresent())
        {
            throw new InvalidOperationException("No value present");
        }

        return Value;
    }

    public LinqOptional<T> ToLinqOptional()
    {
        if (IsPresent())
        {
            return LinqOptional<T>.Of(Get());
        }

        return LinqOptional<T>.Empty();
    }

}

public class LinqOptional<T> : IEnumerable<T>
{
    private readonly T[] _data;

    private LinqOptional(T[] data)
    {
        this._data = data;
    }

    public static LinqOptional<T> Of(T? value)
    {
        if (value == null)
        {
            return Empty();
        }
        return new LinqOptional<T>(new T[] { value });
    }

    public static LinqOptional<T> Empty()
    {
        return new LinqOptional<T>(new T[0]);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)this._data).GetEnumerator();
    }

    IEnumerator
        IEnumerable.GetEnumerator()
    {
        return this._data.GetEnumerator();
    }
}