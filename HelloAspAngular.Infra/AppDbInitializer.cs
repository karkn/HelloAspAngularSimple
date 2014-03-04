using HelloAspAngular.Domain.TodoLists;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloAspAngular.Infra
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            {
                var list = new TodoList()
                {
                    Name = "Archived",
                    Kind = TodoListKind.Archived,
                };
                context.TodoLists.Add(list);
            }
            {
                var list = new TodoList()
                {
                    Name = "List1",
                    Kind = TodoListKind.Normal,
                };
                context.TodoLists.Add(list);
            }
            {
                var list = new TodoList()
                {
                    Name = "List2",
                    Kind = TodoListKind.Normal,
                };
                context.TodoLists.Add(list);
            }
            {
                var list = new TodoList()
                {
                    Name = "List3",
                    Kind = TodoListKind.Normal,
                };
                context.TodoLists.Add(list);
            }

            context.SaveChanges();
        }
    }
}
