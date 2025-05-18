using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoWebApplication.Services;

namespace ToDoWebApplication.Pages
{
    public class TasksModel : PageModel
    {
        public ITaskService TaskService { get; private set; }
        public TasksModel(ITaskService taskService)
        {
            TaskService = taskService;
        }
        public void OnGet()
        {
        }
    }
}
