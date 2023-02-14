namespace Klinkby.Toolkitt;

// hat tip to Jon Skeet
// https://codeblog.jonskeet.uk/2015/01/30/clean-event-handlers-invocation-with-c-6/
public static class EventHandlerExtensions
{
    public static void Raise(this EventHandler? eh, object sender, EventArgs args) =>
        Interlocked.CompareExchange(ref eh, null, null)?.Invoke(sender, args);

    public static void Raise<T>(this EventHandler<T>? eh, object sender, T args) where T: EventArgs =>
        Interlocked.CompareExchange(ref eh, null, null)?.Invoke(sender, args);
}
