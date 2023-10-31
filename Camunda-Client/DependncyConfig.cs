 
using Camunda_Client;
using Microsoft.Extensions.Options;

namespace CamundaClient;

public static class DependncyConfig
{
    public static void AddCamunda(this IServiceCollection services)
    {
        var camundaBuilder =
            services.AddCamundaClient((sp) =>
            {
                var camundaOptions = new CamundaOptions()
                {
                    Url= "http://localhost:8080/engine-rest/engine/default",
                    WorkerId= "TenantManagement",
                    WorkerCount= 1
                };
               // return camundaOptions;
                return sp.GetRequiredService<IOptions<CamundaOptions>>().Value;
            });
        camundaBuilder.AddWorker<CreateOrganizationWorker>(CreateOrganizationWorker.Topics); 
    }
    public static void AddOptionsBinders(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CamundaOptions>(configuration.GetSection("Camunda"));
      

    }
}