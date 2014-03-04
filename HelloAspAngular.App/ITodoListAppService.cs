using HelloAspAngular.Domain.TodoLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloAspAngular.App
{
    public interface ITodoListAppService
    {
        Task<Todo> AddTodoAsync(int todoListId, Todo todo);
        Task UpdateTodoAsync(int todoListId, Todo todo);
        Task ArchiveAsync(int todoListId);
        Task ClearTodosAsync(int todoListId);
    }
}
