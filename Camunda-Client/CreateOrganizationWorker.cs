using Camunda.Worker;

namespace Camunda_Client;

public class CreateOrganizationWorker:ExternalTaskHandler
{
    public static readonly string[] Topics = new[] { "create_organization" };

    

    public override async Task<IExecutionResult> Process(ExternalTask externalTask)
    {
        var test = externalTask.Variables;
        return new CompleteResult();
        
    }
}