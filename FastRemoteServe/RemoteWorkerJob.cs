using FastEndpoints;

namespace FastRemoteServe;

internal class RemoteWorkerJob : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromSeconds(5));
        while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
        {
            CreateOrderCommand remoteCommand = new CreateOrderCommand();
            try
            {
                var result = await remoteCommand.RemoteExecuteAsync();
                Console.WriteLine(result.EventTime.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
