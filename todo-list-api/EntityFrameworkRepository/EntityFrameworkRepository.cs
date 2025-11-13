using System.Collections.ObjectModel;
using TodoList.Core.Abstractions;
using TodoList.Core.Models;

namespace TodoList.EntityFrameworkRepository;

public class EntityFrameworkRepository : IRepository
{
    public Task<ReadOnlyCollection<TodoListModel>> GetAllTodoListsAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<TodoListModel> GetTodoListAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<TodoListModel> InsertTodoListAsync(CreateTodoListInfo todoListInfo, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
