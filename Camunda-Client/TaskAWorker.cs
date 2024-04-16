using Camunda.Worker;

namespace Camunda_Client;

public class TaskAWorker : ExternalTaskHandler
{
	public static readonly string[] Topics = new[] { "TaskAWorker" };


	public override async Task<IExecutionResult> Process(ExternalTask externalTask)
	{
		string? userType = null;
		if (externalTask.Variables.TryGetValue("userType", out var user))
		{
			userType = user.AsString();
		}

		if (!string.IsNullOrEmpty(userType) && userType == "superUser")
		{

			externalTask.Variables.Add("skip", Variable.Boolean(true));

			return new CompleteResult
			{
				Variables = externalTask.Variables
			};
		}


		return new CompleteResult();

	}
}