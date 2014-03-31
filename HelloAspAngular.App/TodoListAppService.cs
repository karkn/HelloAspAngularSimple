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
            using (var tran = _unitOfWork.BeginTransaction())
            {
                var list = new TodoList()
                {
                    Id = todoListId,
                };

                _todoListRepository.Attach(list);
                list.Todos.Add(todo);

                await _unitOfWork.SaveAsync();
                tran.Commit();
                return todo;
            }
        }

        public async Task UpdateTodoAsync(int todoListId, Todo todo)
        {
            using (var tran = _unitOfWork.BeginTransaction())
            {
                var storedList = await _todoListRepository.FindAsync(l => l.Id == todoListId, new[] { "Todos" });
                storedList.ChangeTodo(todo);
                await _unitOfWork.SaveAsync();
                tran.Commit();
            }
        }

        public async Task ArchiveAsync(int todoListId)
        {
            using (var tran = _unitOfWork.BeginTransaction())
            {
                var storedList = await _todoListRepository.FindAsync(l => l.Id == todoListId, new[] { "Todos" });
                await _todoListService.ArchiveAsync(storedList);
                await _unitOfWork.SaveAsync();
                tran.Commit();
            }
        }

        public async Task ClearTodosAsync(int todoListId)
        {
            using (var tran = _unitOfWork.BeginTransaction())
            {
                var storedList = await _todoListRepository.FindAsync(l => l.Id == todoListId, new[] { "Todos" });
                await _todoListService.ClearTodosAsync(storedList);
                await _unitOfWork.SaveAsync();
                tran.Commit();
            }
        }
    }
}
