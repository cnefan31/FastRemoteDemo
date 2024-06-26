using FastEndpoints;

namespace FastRemoteServe;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddHandlerServer();
        builder.Services.AddCors();

        builder.Services.AddHostedService<RemoteWorkerJob>();

        var app = builder.Build();

        app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

        app.MapRemote("http://localhost:8080", c =>
        {
            c.Register<CreateOrderCommand, CreateOrderResult>();
        });

        app.MapHandlers(h =>
        {
            h.Register<CreateOrderCommand, CreateOrderHandler, CreateOrderResult>();
        });

        await app.RunAsync();
    }
}
