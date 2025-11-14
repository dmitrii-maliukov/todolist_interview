using TodoList.Core.Abstractions;
using TodoList.Core.Models;

namespace TodoList.Core.Services;

public class TodoListService : ITodoListService
{
    private readonly IRepository _repository;

    public TodoListService(IRepository repository)
    {
        _repository = repository;
    }

    public Task<TodoListModel> CreateTodoListAsync(
            CreateTodoListInfo todoListInfo,
            CancellationToken ct) =>
        _repository.InsertTodoListAsync(todoListInfo, ct);

    public Task<TodoListsPaginationResult> GetTodoListsAsync(
            GetTodoListsFilter filter,
            CancellationToken ct) =>
        _repository.GetTodoListsAsync(filter, ct);

    public Task DeleteAsync(
            Guid todoListId,
            CancellationToken ct) =>
        _repository.DeleteTodoListAsync(todoListId, ct);
}