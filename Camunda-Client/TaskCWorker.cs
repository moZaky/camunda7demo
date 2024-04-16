using Camunda.Worker;

namespace Camunda_Client
{

	public class TaskCWorker : ExternalTaskHandler
	{
		public static readonly string[] Topics = new[] { "TaskCWorker" };



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
