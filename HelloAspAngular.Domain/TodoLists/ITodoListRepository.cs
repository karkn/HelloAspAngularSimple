using HelloAspAngular.Domain;
using HelloAspAngular.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloAspAngular.Domain.TodoLists
{
    public interface ITodoListRepository: IRepository<TodoList>
    {
        void UpdateTodo(Todo todo);
        void RemoveTodos(IEnumerable<Todo> todos);
    }
}
