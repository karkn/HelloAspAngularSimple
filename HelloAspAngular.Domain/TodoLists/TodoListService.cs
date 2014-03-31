using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloAspAngular.Domain.TodoLists
{
    public class TodoListService: ITodoListService
    {
        private ITodoListRepository _todoListRepository;

        public TodoListService(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public async Task ArchiveAsync(TodoList todoList)
        {
            var archivedTodoList = await _todoListRepository.FindAsync(l => l.Kind == TodoListKind.Archived);

            var todos = todoList.GetTodosShouldBeArchived();
            foreach (var todo in todos)
            {
                todo.TodoList = archivedTodoList;
            }
        }

        public Task ClearTodosAsync(TodoList todoList)
        {
            var todos = todoList.Todos.ToArray();
            todoList.Todos.Clear();
            _todoListRepository.RemoveTodos(todos);
            return Task.FromResult(0);
        }
    }
}
