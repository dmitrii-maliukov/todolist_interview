using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Converters;
using TodoList.Api.Models;
using TodoList.Core.Abstractions;
using TodoList.Core.Models;

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
    public async Task<ActionResult<GetApiTodoListsModel>> GetAsync(
        int? pageSize,
        int? pageNumber,
        CancellationToken ct)
    {
        var result = await _todoListService
            .GetTodoListsAsync(new GetTodoListsFilter(pageSize, pageNumber), ct);

        return Ok(result.ToTodoListsPaginationResult());
    }

    [HttpPost]
    [Produces(typeof(ApiTodoListModel))]
    public async Task<IActionResult> CreateAsync(
        CreateTodoListRequest newTodoList,
        CancellationToken ct)
    {
        var added = await _todoListService
            .CreateTodoListAsync(newTodoList.ToCoreTodoListModel(), ct);
        return Created("api/todo-lists", added.ToApiTodoListModel());
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
        Guid id,
        CancellationToken ct)
    {
        await _todoListService.DeleteAsync(id, ct);
        return Ok();
    }

}