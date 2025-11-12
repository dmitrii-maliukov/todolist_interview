using System.Collections.ObjectModel;
using TodoList.Core.Models;

namespace TodoList.Core.Abstractions;

public interface ITodoListService
{
    Task<TodoListModel> CreateTodoListAsync(CreateTodoListInfo todoListInfo, CancellationToken ct);

    Task<ReadOnlyCollection<TodoListModel>> GetAllTodoListsAsync(CancellationToken ct);
}