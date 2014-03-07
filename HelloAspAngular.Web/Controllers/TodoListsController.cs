using AutoMapper;
using HelloAspAngular.App;
using HelloAspAngular.Domain.TodoLists;
using HelloAspAngular.Web.Api.ResourceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace HelloAspAngular.Web.Controllers
{
    public class TodoListsController : ApiController
    {
        private ITodoListAppService _todoListAppService;
        private ITodoListRepository _todoListRepository;

        public TodoListsController(ITodoListAppService todoListService, ITodoListRepository todoListRepository)
        {
            _todoListAppService = todoListService;
            _todoListRepository = todoListRepository;
        }

        // GET api/todolists
        public async Task<IHttpActionResult> Get()
        {
            var lists = await _todoListRepository.FindAllAsync(l => l.Kind == TodoListKind.Normal);
            return Ok(Mapper.Map<IEnumerable<TodoListResourceModel>>(lists));
        }

        // GET api/todolists/{id}
        public async Task<IHttpActionResult> Get(int id)
        {
            var list = await _todoListRepository.FindAsync(l => l.Id == id, new[] { "Todos" });
            var listRm = Mapper.Map<TodoListDetailResourceModel>(list);
            return Ok(listRm);
        }

        // POST api/todolists/{id}/todos
        [Route("api/todolists/{id}/todos")]
        public async Task<IHttpActionResult> PostTodo(int id, TodoResourceModel input)
        {
            var todo = Mapper.Map<Todo>(input);

            var ret = await _todoListAppService.AddTodoAsync(id, todo);

            var todoRm = Mapper.Map<TodoResourceModel>(ret);
            var path = string.Format("~/api/todolists/{0}/todos/{1}", id, ret.Id);
            var uri = Url.Content(path);
            return Created(uri, todoRm);
        }

        // PUT api/todolists/{id}/todos/{todoId}
        [Route("api/todolists/{id}/todos/{todoId}")]
        public async Task<IHttpActionResult> PutTodo(int id, int todoId, TodoResourceModel input)
        {
            var todo = Mapper.Map<Todo>(input);
            todo.Id = todoId;
            await _todoListAppService.UpdateTodoAsync(id, todo);
            return Ok(string.Empty);
        }

        // GET api/todolists/archived
        [Route("api/todolists/archived")]
        public async Task<IHttpActionResult> GetArchived()
        {
            var list = await _todoListRepository.FindAsync(l => l.Kind == TodoListKind.Archived, new[] { "Todos" });
            var listRm = Mapper.Map<TodoListDetailResourceModel>(list);
            return Ok(listRm);
        }

        // DELETE api/todolists/{id}/clear
        [Route("api/todolists/{id}/clear")]
        public async Task<IHttpActionResult> DeleteTodos(int id)
        {
            await _todoListAppService.ClearTodosAsync(id);
            return Ok(string.Empty);
        }

        // PUT api/todolists/{id}/archive
        [Route("api/todolists/{id}/archive")]
        public async Task<IHttpActionResult> PutArchive(int id)
        {
            await _todoListAppService.ArchiveAsync(id);
            return Ok(string.Empty);
        }
    }
}