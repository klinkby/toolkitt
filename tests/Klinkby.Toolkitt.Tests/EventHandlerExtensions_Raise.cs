namespace Klinkby.Toolkitt.Tests;

public class EventHandlerExtensions_Raise
{
    private static readonly EventArgs EventArgsObj = new EventArgs();

    private class EventMock
    {
        public void OnInvoked() => Invoked.Raise(this, EventArgsObj);
#pragma warning disable S3264 // Events should be invoked
        public event EventHandler? Invoked;
#pragma warning restore S3264 // Events should be invoked
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void NoListener_Should_DoNothing()
    {
        var mock = new EventMock();
        mock.OnInvoked();
       Assert.NotNull(mock); // dummy assertion, just ensure no exceptions raised
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void Subscriber_Should_Raise()
    {
        int times = 0;
        var mock = new EventMock();
        (object? Sender, EventArgs EventArgs) args = default;
        mock.Invoked += (sender, ea) =>
        {
            args = (sender, ea);
            times++;
        };
        mock.OnInvoked();
        Assert.Equal(1, times);
        Assert.Equal(mock, args.Sender);
        Assert.Equal(EventArgsObj, args.EventArgs);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void Unsubscriber_Should_DoNothing()
    {
        int times = 0;
        var mock = new EventMock();
        var eh = new EventHandler((object? _, EventArgs _) => times++);
        mock.Invoked += eh;
        mock.Invoked -= eh;
        mock.OnInvoked();
        Assert.Equal(0, times);
    }
}