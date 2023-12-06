namespace Klinkby.Toolkitt;

/// <summary>
/// Provide extension methods for enumerating values of tuples that have a single item type.
/// </summary>
public static class TupleEnumerator
{
    /// <summary>
    /// Get an enumerable for the items in a tuple that has identical item types.
    /// </summary>
    /// <param name="tuple">Source</param>
    /// <typeparam name="T">Type of Tuple items</typeparam>
    /// <returns>Enumerable items</returns>
    public static IEnumerable<T> ToEnumerable<T>(this Tuple<T, T> tuple)
    {
        yield return tuple.Item1;
        yield return tuple.Item2;
    }

    /// <summary>
    /// Get an enumerable for the items in a tuple that has identical item types.
    /// </summary>
    /// <param name="tuple">Source</param>
    /// <typeparam name="T">Type of Tuple items</typeparam>
    /// <returns>Enumerable items</returns>
    public static IEnumerable<T> ToEnumerable<T>(this Tuple<T, T, T> tuple)
    {
        yield return tuple.Item1;
        yield return tuple.Item2;
        yield return tuple.Item3;
    }

    /// <summary>
    /// Get an enumerable for the items in a tuple that has identical item types.
    /// </summary>
    /// <param name="tuple">Source</param>
    /// <typeparam name="T">Type of Tuple items</typeparam>
    /// <returns>Enumerable items</returns>
    public static IEnumerable<T> ToEnumerable<T>(this Tuple<T, T, T, T> tuple)
    {
        yield return tuple.Item1;
        yield return tuple.Item2;
        yield return tuple.Item3;
        yield return tuple.Item4;
    }
    
    /// <summary>
    /// Get an enumerable for the items in a tuple that has identical item types.
    /// </summary>
    /// <param name="tuple">Source</param>
    /// <typeparam name="T">Type of Tuple items</typeparam>
    /// <returns>Enumerable items</returns>
    public static IEnumerable<T> ToEnumerable<T>(this Tuple<T, T, T, T, T> tuple)
    {
        yield return tuple.Item1;
        yield return tuple.Item2;
        yield return tuple.Item3;
        yield return tuple.Item4;
        yield return tuple.Item5;
    }

    /// <summary>
    /// Get an enumerable for the items in a tuple that has identical item types.
    /// </summary>
    /// <param name="tuple">Source</param>
    /// <typeparam name="T">Type of Tuple items</typeparam>
    /// <returns>Enumerable items</returns>
    public static IEnumerable<T> ToEnumerable<T>(this Tuple<T, T, T, T, T, T> tuple)
    {
        yield return tuple.Item1;
        yield return tuple.Item2;
        yield return tuple.Item3;
        yield return tuple.Item4;
        yield return tuple.Item5;
        yield return tuple.Item6;
    }
    
    /// <summary>
    /// Get an enumerable for the items in a tuple that has identical item types.
    /// </summary>
    /// <param name="tuple">Source</param>
    /// <typeparam name="T">Type of Tuple items</typeparam>
    /// <returns>Enumerable items</returns>
    public static IEnumerable<T> ToEnumerable<T>(this Tuple<T, T, T, T, T, T, T> tuple)
    {
        yield return tuple.Item1;
        yield return tuple.Item2;
        yield return tuple.Item3;
        yield return tuple.Item4;
        yield return tuple.Item5;
        yield return tuple.Item6;
        yield return tuple.Item7;
    }
}