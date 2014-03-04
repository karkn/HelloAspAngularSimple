using HelloAspAngular.Domain;
using HelloAspAngular.Domain.TodoLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloAspAngular.Infra.TodoLists
{
    public class TodoListRepository : Repository<TodoList, AppContext>, ITodoListRepository
    {
        public TodoListRepository(AppContext context): base(context)
        {
        }

        public void UpdateTodo(Todo todo)
        {
            Context.Todos.Attach(todo);
            var entry = Context.Entry(todo);
            entry.Property(t => t.IsDone).IsModified = true;
            entry.Property(t => t.Text).IsModified = true;
        }

        public void RemoveTodos(IEnumerable<Todo> todos)
        {
            Context.Todos.RemoveRange(todos);
        }
    }
}
