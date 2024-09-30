namespace myapp.domain.utils;

/***
 * functional aproach to Nullable elements
 * why do this? ->
 * https://www.pluralsight.com/courses/making-functional-csharp?clickid=28ATldy9ZxyKR7BRAu10gy-OUkCUwu0e6x4GRk0&irgwc=1&mpid=1220429&aid=7010a000001xAKZAA2
 * https://www.pluralsight.com/courses/tactical-design-patterns-dot-net-control-flow?clickid=28DybYy9ZxyKR7BRAu10gy-OUkCUwu0P6x4GRk0&irgwc=1&mpid=1220429&aid=7010a000001xAKZAA2
 * https://stackoverflow.com/questions/16199227/optional-return-in-c-net
 */
public class Option<T> : IEnumerable<T>
{
    private readonly T[] _data;

    private Option(T[] data)
    {
        this._data = data;
    }

    public static Option<T> Create(T value)
    {
        return new Option<T>(new T[] { value });
    }

    public static Option<T> CreateEmpty()
    {
        return new Option<T>(new T[0]);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)this._data).GetEnumerator();
    }

    System.Collections.IEnumerator
        System.Collections.IEnumerable.GetEnumerator()
    {
        return this._data.GetEnumerator();
    }
}