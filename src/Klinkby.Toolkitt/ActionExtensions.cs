namespace Klinkby.Toolkitt;

/// <summary>Extensions for <see cref="Action{TResult}"/></summary>
public static class ActionExtensions
{
    /// <summary>
    /// Apply the parameter to an action with 1 parameter
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    public static Action Apply<T1>(this Action<T1> func, T1 t1)
        => () => func(t1);

    /// <summary>
    /// Apply first parameter to a function with 2 parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    public static Action<T2> Apply<T1, T2>(this Action<T1, T2> func, T1 t1)
        => t2 => func(t1, t2);

    /// <summary>
    /// Apply 2 parameters to a function with 2 parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    public static Action Apply<T1, T2>(this Action<T1, T2> func, T1 t1, T2 t2)
        => () => func(t1, t2);

    /// <summary>
    /// Apply first parameter to a function with 3 parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    public static Action<T2, T3> Apply<T1, T2, T3>(this Action<T1, T2, T3> func, T1 t1)
        => (t2, t3) => func(t1, t2, t3);

    /// <summary>
    /// Apply 2 parameters to a function with 3 parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    public static Action<T3> Apply<T1, T2, T3>(this Action<T1, T2, T3> func, T1 t1, T2 t2)
        => (t3) => func(t1, t2, t3);

    /// <summary>
    /// Apply 3 parameters to a function with 3 parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    public static Action Apply<T1, T2, T3>(this Action<T1, T2, T3> func, T1 t1, T2 t2, T3 t3)
        => () => func(t1, t2, t3);
}
