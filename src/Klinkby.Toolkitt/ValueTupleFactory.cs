using System.Diagnostics;

namespace Klinkby.Toolkitt;

/// <summary>
///     Extensions methods for converting IEnumerable{T} to ValueTuple{T}
/// </summary>
public static class ValueTupleFactory
{
    /// <summary>
    ///     Try enumerating collection values into a ValueTuple.
    /// </summary>
    /// <param name="collection">Source values</param>
    /// <param name="tuple">Target <see cref="ValueTuple" /></param>
    /// <typeparam name="T">Value type</typeparam>
    /// <returns>True if all the tuple's values could be read</returns>
    public static bool TryToValueTuple<T>(this IEnumerable<T> collection, out ValueTuple<T, T> tuple)
    {
        Debug.Assert(collection != null, nameof(collection) + " != null");
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
        tuple = new ValueTuple<T, T>(t1, t2);
        return true;
    }

    /// <summary>
    ///     Try enumerating collection values into a ValueTuple.
    /// </summary>
    /// <param name="collection">Source values</param>
    /// <param name="tuple">Target <see cref="ValueTuple" /></param>
    /// <typeparam name="T">Value type</typeparam>
    /// <returns>True if all the tuple's values could be read</returns>
    public static bool TryToValueTuple<T>(this IEnumerable<T> collection, out ValueTuple<T, T, T> tuple)
    {
        Debug.Assert(collection != null, nameof(collection) + " != null");
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
        tuple = new ValueTuple<T, T, T>(t1, t2, t3);
        return true;
    }

    /// <summary>
    ///     Try enumerating collection values into a ValueTuple.
    /// </summary>
    /// <param name="collection">Source values</param>
    /// <param name="tuple">Target <see cref="ValueTuple" /></param>
    /// <typeparam name="T">Value type</typeparam>
    /// <returns>True if all the tuple's values could be read</returns>
    public static bool TryToValueTuple<T>(this IEnumerable<T> collection, out ValueTuple<T, T, T, T> tuple)
    {
        Debug.Assert(collection != null, nameof(collection) + " != null");
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
        tuple = new ValueTuple<T, T, T, T>(t1, t2, t3, t4);
        return true;
    }

    /// <summary>
    ///     Try enumerating collection values into a ValueTuple.
    /// </summary>
    /// <param name="collection">Source values</param>
    /// <param name="tuple">Target <see cref="ValueTuple" /></param>
    /// <typeparam name="T">Value type</typeparam>
    /// <returns>True if all the tuple's values could be read</returns>
    public static bool TryToValueTuple<T>(this IEnumerable<T> collection, out ValueTuple<T, T, T, T, T> tuple)
    {
        Debug.Assert(collection != null, nameof(collection) + " != null");
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
        tuple = new ValueTuple<T, T, T, T, T>(t1, t2, t3, t4, t5);
        return true;
    }
    
    /// <summary>
    ///     Try enumerating collection values into a ValueTuple.
    /// </summary>
    /// <param name="collection">Source values</param>
    /// <param name="tuple">Target <see cref="ValueTuple" /></param>
    /// <typeparam name="T">Value type</typeparam>
    /// <returns>True if all the tuple's values could be read</returns>
    public static bool TryToValueTuple<T>(this IEnumerable<T> collection, out ValueTuple<T, T, T, T, T, T> tuple)
    {
        Debug.Assert(collection != null, nameof(collection) + " != null");
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
        tuple = new ValueTuple<T, T, T, T, T, T>(t1, t2, t3, t4, t5, t6);
        return true;
    }

    /// <summary>
    ///     Try enumerating collection values into a ValueTuple.
    /// </summary>
    /// <param name="collection">Source values</param>
    /// <param name="tuple">Target <see cref="ValueTuple" /></param>
    /// <typeparam name="T">Value type</typeparam>
    /// <returns>True if all the tuple's values could be read</returns>
    public static bool TryToValueTuple<T>(this IEnumerable<T> collection, out ValueTuple<T, T, T, T, T, T, T> tuple)
    {
        Debug.Assert(collection != null, nameof(collection) + " != null");
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
        tuple = new ValueTuple<T, T, T, T, T, T, T>(t1, t2, t3, t4, t5, t6, t7);
        return true;
    }
}