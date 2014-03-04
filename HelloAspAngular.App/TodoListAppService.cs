using HelloAspAngular.Domain;
using HelloAspAngular.Domain.TodoLists;
using HelloAspAngular.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloAspAngular.App
{
    public class TodoListAppService: ITodoListAppService
    {
        private IUnitOfWork _unitOfWork;
        private ITodoListService _todoListService;
        private ITodoListRepository _todoListRepository;

        public TodoListAppService(IUnitOfWork unitOfWork, ITodoListService todoListService, ITodoListRepository todoListRepository)
        {
            _unitOfWork = unitOfWork;
            _todoListService = todoListService;
            _todoListRepository = todoListRepository;
        }

        public async Task<Todo> AddTodoAsync(int todoListId, Todo todo)
        {
            var list = new TodoList()
            {
                Id = todoListId,
            };

            _todoListRepository.Attach(list);
            list.Todos.Add(todo);

            await _unitOfWork.SaveAsync();

            return todo;
        }

        public async Task UpdateTodoAsync(int todoListId, Todo todo)
        {
            _todoListRepository.UpdateTodo(todo);

            await _unitOfWork.SaveAsync();
        }

        public async Task ArchiveAsync(int todoListId)
        {
            var storedList = await _todoListRepository.FindAsync(l => l.Id == todoListId, new[] { "Todos" });
            await _todoListService.ArchiveAsync(storedList);
            await _unitOfWork.SaveAsync();
        }

        public async Task ClearArchivedTodosAsync()
        {
            await _todoListService.ClearArchivedTodosAsync();
            await _unitOfWork.SaveAsync();
        }
    }
}
