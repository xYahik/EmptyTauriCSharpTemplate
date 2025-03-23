namespace EmptyTauri.TauriPlugIn;

using TauriDotNetBridge.Contracts;

public class BaseService(IEventPublisher publisher) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(30));
        while (await timer.WaitForNextTickAsync(cancellationToken))
        {
            publisher.Publish("base-service", $"Sent String");
        }
    }
}
