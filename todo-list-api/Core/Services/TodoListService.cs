using System.Collections.ObjectModel;
using TodoList.Core.Abstractions;
using TodoList.Core.Models;

namespace TodoList.Core.Services;

public class TodoListService : ITodoListService
{
    // NB: always readonly
    private readonly IRepository _repository;

    public TodoListService(IRepository repository)
    {
        _repository = repository;
    }

    public Task<TodoListModel> CreateTodoListAsync(
            CreateTodoListInfo todoListInfo,
            CancellationToken ct) =>
        _repository.InsertTodoListAsync(todoListInfo, ct);

    public Task<ReadOnlyCollection<TodoListModel>> GetAllTodoListsAsync(
            CancellationToken ct) =>
        _repository.GetAllTodoListsAsync(ct);
}