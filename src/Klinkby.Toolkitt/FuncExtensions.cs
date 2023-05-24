namespace Klinkby.Toolkitt;

/// <summary>Extensions for <see cref="Func{TResult}"/></summary>
public static class FuncExtensions
{
    /// <summary>
    /// Apply the parameter to a function with 1 parameter
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="TResult">Type of result</typeparam>
    public static Func<TResult> Apply<T1, TResult>(this Func<T1, TResult> func, T1 t1)
        => () => func(t1);

    /// <summary>
    /// Apply first parameter to a function with 2 parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="TResult">Type of result</typeparam>
    public static Func<T2, TResult> Apply<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 t1)
        => t2 => func(t1, t2);

    /// <summary>
    /// Apply 2 parameters to a function with 2 parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="TResult">Type of result</typeparam>
    public static Func<TResult> Apply<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 t1, T2 t2)
        => () => func(t1, t2);

    /// <summary>
    /// Apply first parameter to a function with 3 parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="TResult">Type of result</typeparam>
    public static Func<T2, T3, TResult> Apply<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 t1)
        => (t2, t3) => func(t1, t2, t3);

    /// <summary>
    /// Apply 2 parameters to a function with 3 parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="TResult">Type of result</typeparam>
    public static Func<T3, TResult> Apply<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 t1, T2 t2)
        => t3 => func(t1, t2, t3);

    /// <summary>
    /// Apply 3 parameters to a function with 3 parameters
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="TResult">Type of result</typeparam>
    public static Func<TResult> Apply<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 t1, T2 t2, T3 t3)
        => () => func(t1, t2, t3);


    /// <summary>
    /// Curry a function with 2 parameters
    /// Currying is the process of transforming a function that takes multiple arguments into a function that takes just a single argument and returns another functions for remaining arguments needed.
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="TResult">Type of result</typeparam>
    /// <param name="func"></param>
    /// <returns></returns>
    public static Func<T1, Func<T2, TResult>> Curry<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        => t1 => t2 => func(t1, t2);

    /// <summary>
    /// Curry a function with 3 parameters. 
    /// Currying is the process of transforming a function that takes multiple arguments into a function that takes just a single argument and returns another functions for remaining arguments needed.
    /// </summary>
    /// <typeparam name="T1">Type of first parameter</typeparam>
    /// <typeparam name="T2">Type of second parameter</typeparam>
    /// <typeparam name="T3">Type of third parameter</typeparam>
    /// <typeparam name="TResult">Type of result</typeparam>
    /// <param name="func"></param>
    /// <returns></returns>
    public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func)
        => t1 => t2 => t3 => func(t1, t2, t3);

    /// <summary>
    /// Uncurry a function to take 2 parameters. 
    /// Uncurrying is the process of transforming a function that takes a single argument and returns another function into a function that takes all its arguments at once.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="func"></param>
    /// <returns></returns>
    public static Func<T1, T2, TResult> UnCurry<T1, T2, TResult>(this Func<T1, Func<T2, TResult>> func)
        => (t1, t2) => func(t1)(t2);

    /// <summary>
    /// Uncurry a function to take 3 parameters. 
    /// Uncurrying is the process of transforming a function that takes a single argument and returns another function into a function that takes all its arguments at once.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="func"></param>
    /// <returns></returns>
    public static Func<T1, T2, T3, TResult> UnCurry<T1, T2, T3, TResult>(this Func<T1, Func<T2, Func<T3, TResult>>> func)
        => (t1, t2, t3) => func(t1)(t2)(t3);
}
