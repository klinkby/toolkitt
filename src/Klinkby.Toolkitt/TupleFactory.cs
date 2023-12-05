namespace Klinkby.Toolkitt;

/// <summary>
///     Extensions methods for converting IEnumerable{T} to Tuple{T}
/// </summary>
public static class TupleFactory
{
    /// <summary>
    ///     Try enumerating collection values into a Tuple.
    /// </summary>
    /// <param name="collection">Source values</param>
    /// <param name="tuple">Target <see cref="Tuple" /></param>
    /// <typeparam name="T">Value type</typeparam>
    /// <returns>True if all the tuple's values could be read</returns>
    public static bool TryToTuple<T>(this IEnumerable<T> collection, [NotNullWhen(true)] out Tuple<T, T>? tuple)
    {
        using var e = collection.GetEnumerator();
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t1 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t2 = e.Current;
        tuple = new Tuple<T, T>(t1, t2);
        return true;
    }

    /// <summary>
    ///     Try enumerating collection values into a Tuple.
    /// </summary>
    /// <param name="collection">Source values</param>
    /// <param name="tuple">Target <see cref="Tuple" /></param>
    /// <typeparam name="T">Value type</typeparam>
    /// <returns>True if all the tuple's values could be read</returns>
    public static bool TryToTuple<T>(this IEnumerable<T> collection, [NotNullWhen(true)] out Tuple<T, T, T>? tuple)
    {
        using var e = collection.GetEnumerator();
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t1 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t2 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t3 = e.Current;
        tuple = new Tuple<T, T, T>(t1, t2, t3);
        return true;
    }

    /// <summary>
    ///     Try enumerating collection values into a Tuple.
    /// </summary>
    /// <param name="collection">Source values</param>
    /// <param name="tuple">Target <see cref="Tuple" /></param>
    /// <typeparam name="T">Value type</typeparam>
    /// <returns>True if all the tuple's values could be read</returns>
    public static bool TryToTuple<T>(this IEnumerable<T> collection, [NotNullWhen(true)] out Tuple<T, T, T, T>? tuple)
    {
        using var e = collection.GetEnumerator();
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t1 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t2 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t3 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t4 = e.Current;
        tuple = new Tuple<T, T, T, T>(t1, t2, t3, t4);
        return true;
    }

    /// <summary>
    ///     Try enumerating collection values into a Tuple.
    /// </summary>
    /// <param name="collection">Source values</param>
    /// <param name="tuple">Target <see cref="Tuple" /></param>
    /// <typeparam name="T">Value type</typeparam>
    /// <returns>True if all the tuple's values could be read</returns>
    public static bool TryToTuple<T>(this IEnumerable<T> collection, [NotNullWhen(true)] out Tuple<T, T, T, T, T>? tuple)
    {
        using var e = collection.GetEnumerator();
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t1 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t2 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t3 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t4 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t5 = e.Current;
        tuple = new Tuple<T, T, T, T, T>(t1, t2, t3, t4, t5);
        return true;
    }

    /// <summary>
    ///     Try enumerating collection values into a Tuple.
    /// </summary>
    /// <param name="collection">Source values</param>
    /// <param name="tuple">Target <see cref="Tuple" /></param>
    /// <typeparam name="T">Value type</typeparam>
    /// <returns>True if all the tuple's values could be read</returns>
    public static bool TryToTuple<T>(this IEnumerable<T> collection, [NotNullWhen(true)] out Tuple<T, T, T, T, T, T>? tuple)
    {
        using var e = collection.GetEnumerator();
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t1 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t2 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t3 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t4 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t5 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t6 = e.Current;
        tuple = new Tuple<T, T, T, T, T, T>(t1, t2, t3, t4, t5, t6);
        return true;
    }
    
    
    /// <summary>
    ///     Try enumerating collection values into a Tuple.
    /// </summary>
    /// <param name="collection">Source values</param>
    /// <param name="tuple">Target <see cref="Tuple" /></param>
    /// <typeparam name="T">Value type</typeparam>
    /// <returns>True if all the tuple's values could be read</returns>
    public static bool TryToTuple<T>(this IEnumerable<T> collection, [NotNullWhen(true)] out Tuple<T, T, T, T, T, T, T>? tuple)
    {
        using var e = collection.GetEnumerator();
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t1 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t2 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t3 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t4 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t5 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t6 = e.Current;
        if (!e.MoveNext())
        {
            tuple = default;
            return false;
        }

        var t7 = e.Current;
        tuple = new Tuple<T, T, T, T, T, T, T>(t1, t2, t3, t4, t5, t6, t7);
        return true;
    }
}