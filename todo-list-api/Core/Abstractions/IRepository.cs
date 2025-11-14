using System.Collections.ObjectModel;
using TodoList.Core.Models;

namespace TodoList.Core.Abstractions;

public interface IRepository
{
    /// <summary>
    /// Inserts new todo list to the storage
    /// </summary>
    /// <param name="todoListInfo">Info about this new todo list</param>
    /// <returns>Added todo list record</returns>
    Task<TodoListModel> InsertTodoListAsync(
        CreateTodoListInfo todoListInfo,
        CancellationToken ct);

    /// <summary>
    /// Fetches a number of todo list records by the given pagination in <paramref name="filter"/>
    /// </summary>
    /// <param name="filter">Pagination parameters</param>
    Task<TodoListsPaginationResult> GetTodoListsAsync(
        GetTodoListsFilter filter,
        CancellationToken ct);

    /// <summary>
    /// Fetches one todo list record by given unique id
    /// </summary>
    /// <param name="id">Unique id of todo list record</param>
    /// <returns>Found record</returns>
    Task<TodoListModel> GetTodoListAsync(Guid id, CancellationToken ct);
}