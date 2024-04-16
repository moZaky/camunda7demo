using Camunda.Worker;
using Microsoft.Extensions.Options;

namespace Camunda_Client
{

	public class TaskBWorker : ExternalTaskHandler
	{
		public static readonly string[] Topics = new[] { "TaskBWorker" };
		private CamundaOptions camundaOptions { get; set; }
		public TaskBWorker(IOptions<CamundaOptions> options)
		{
			camundaOptions = options.Value;

		}

		public override async Task<IExecutionResult> Process(ExternalTask externalTask)
		{
			bool? isSkipped = null;
			if (externalTask.Variables.TryGetValue("skip", out var skipped))
			{
				isSkipped = skipped.AsBoolean();
			}

			if (isSkipped.HasValue && isSkipped.Value == true)
			{

				return new CompleteResult();

			}
			//do your logic here

			return new CompleteResult();

		}
	}
}
