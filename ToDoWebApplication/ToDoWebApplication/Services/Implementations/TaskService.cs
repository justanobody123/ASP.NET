using System.Reflection;
using ToDoWebApplication.Models;

namespace ToDoWebApplication.Services.Implementations
{
	public class TaskService : ITaskService
	{
		public List<UserTask> GetTasks()
		{
			return new List<UserTask>() {
				new UserTask() {Title = "First Task", Description = "Description"}
			};
		}
	}
}
