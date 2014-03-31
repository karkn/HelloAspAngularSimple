using HelloAspAngular.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloAspAngular.Domain.TodoLists
{
    public class TodoList
    {
        public TodoList()
        {
            Todos = new List<Todo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public TodoListKind Kind { get; set; }
        public virtual ICollection<Todo> Todos { get; private set; }

        public IEnumerable<Todo> GetTodosShouldBeArchived()
        {
            return Todos.Where(t => t.IsDone).ToArray();
        }

        public void ChangeTodo(Todo todo)
        {
            var storedTodo = Todos.FirstOrDefault(t => t.Id == todo.Id);
            storedTodo.IsDone = todo.IsDone;
            storedTodo.Text = todo.Text;
        }
    }

    public enum TodoListKind: byte
    {
        Normal = 0,
        Archived = 1,
    }
}
