using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Converters;
using TodoList.Api.Models;
using TodoList.Core.Abstractions;

namespace TodoList.Api.Controllers;

[ApiController]
[Route("api/todo-lists")]
public class TodoListsController : ControllerBase
{
    private readonly ITodoListService _todoListService;

    public TodoListsController(ITodoListService todoListService)
    {
        _todoListService = todoListService;
    }

    [HttpGet]
    [Produces(typeof(GetApiTodoListsModel))]
    public async Task<ActionResult<GetApiTodoListsModel>> GetAllTodoListsAsync(
        CancellationToken ct)
    {
        var todoLists = await _todoListService.GetAllTodoListsAsync(ct);
        return Ok(new GetApiTodoListsModel
        {
            Items = todoLists.Select(x => x.ToApiTodoListModel())
        });
    }

    [HttpPost]
    [Produces(typeof(ApiTodoListModel))]
    public async Task<IActionResult> CreateTodoList(
        CreateTodoListRequest newTodoList,
        CancellationToken ct)
    {
        var added = await _todoListService
            .CreateTodoListAsync(newTodoList.ToCoreTodoListModel(), ct);
        return Created("api/todo-lists", added);
    }
}