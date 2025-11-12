using System.Collections.ObjectModel;
using TodoList.Core.Models;

namespace TodoList.Core.Abstractions;

public interface IRepository
{
    Task<TodoListModel> InsertTodoListAsync(CreateTodoListInfo todoListInfo, CancellationToken ct);

    Task<ReadOnlyCollection<TodoListModel>> GetAllTodoListsAsync(CancellationToken ct);

    Task<TodoListModel> GetTodoListAsync(Guid id, CancellationToken ct);
}