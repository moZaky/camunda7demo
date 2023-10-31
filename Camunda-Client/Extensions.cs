using Camunda.Api.Client;
using Camunda.Worker;
using Camunda.Worker.Execution;
using Camunda.Worker.Extensions;
using CamundaClient;
using Microsoft.Extensions.Options;
using Camunda.Api.Client;
using Camunda.Worker;

namespace Camunda_Client;
public class CamundaOptions
{
    public string Url { get; set; }

    public int WorkerCount { get; set; }

    public string WorkerId { get; set; }
}
 
public static class Extensions
{
    
    public static CamundaWorkerBuilder AddCamundaClient(this IServiceCollection services, Func<IServiceProvider, CamundaOptions> configure)
    {
        ServiceProvider arg = services.BuildServiceProvider();
        CamundaOptions options = configure(arg);
        services.AddTransient((IServiceProvider sp) =>  Camunda.Api.Client.CamundaClient.Create(options.Url));
       // services.AddScoped<IBpmnEngineClient, CamundaEngineClient>();
        ICamundaWorkerBuilder builder = services.AddCamundaWorker(delegate (CamundaWorkerOptions config)
        {
            config.BaseUri = new Uri(options.Url);
            config.WorkerCount = options.WorkerCount;
            config.WorkerId = options.WorkerId;
        });
        return new CamundaWorkerBuilder(builder);
    }
}

 
public class CamundaWorkerBuilder
{
    private readonly ICamundaWorkerBuilder _builder;

    public CamundaWorkerBuilder(ICamundaWorkerBuilder builder)
    {
        _builder = builder;
    }

    public CamundaWorkerBuilder AddWorker<T>(params string[] topics) where T : class, IExternalTaskHandler
    {
        _builder.AddHandler<T>(new HandlerMetadata(topics, 10000));
        return this;
    }
}
