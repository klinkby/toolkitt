namespace Klinkby.Toolkitt;

// hat tip to Jon Skeet
// https://codeblog.jonskeet.uk/2015/01/30/clean-event-handlers-invocation-with-c-6/

/// <summary>Raises events</summary>
public static class EventHandlerExtensions
{
    /// <summary>
    ///     Invoke an event handler, thread safe.
    /// </summary>
    /// <param name="eh">The event handler to invoke</param>
    /// <param name="sender">Event emitter instance</param>
    /// <param name="args">
    ///     <see cref="EventArgs" />
    /// </param>
    /// <example>
    ///     <code>
    /// public EventHandler Click;
    /// protected void OnClick()
    /// {
    ///     Click.Raise(this, new ClickEventArgs(x, y));  
    /// }
    /// </code>
    /// </example>
    public static void Raise(this EventHandler? eh, object sender, EventArgs args) 
        => Interlocked.CompareExchange(ref eh, null, null)?.Invoke(sender, args);

    /// <summary>
    ///     Invoke an event handler, thread safe.
    /// </summary>
    /// <param name="eh">The event handler to invoke</param>
    /// <param name="sender">Event emitter instance</param>
    /// <example>
    ///     <code>
    /// public EventHandler Click;
    /// protected void OnClick()
    /// {
    ///     Click.Raise(this);  
    /// }
    /// </code>
    /// </example>
    public static void Raise(this EventHandler? eh, object sender) 
        => Interlocked.CompareExchange(ref eh, null, null)?.Invoke(sender, EventArgs.Empty);

    /// <summary>
    ///     Invoke an event handler, thread safe.
    /// </summary>
    /// <param name="eh">The event handler to invoke</param>
    /// <param name="sender">Event emitter instance</param>
    /// <param name="args"><see cref="EventArgs" /> subclass</param>
    /// <example>
    ///     <code><!--
    /// public EventHandler<ClickEventArgs> Click;
    /// protected void OnClick(int x, int y)
    /// {
    ///     Click.Raise(this, new ClickEventArgs(x, y));
    /// }
    /// --></code>
    /// </example>
    public static void Raise<T>(this EventHandler<T>? eh, object sender, T args) where T : EventArgs 
        => Interlocked.CompareExchange(ref eh, null, null)?.Invoke(sender, args);
}