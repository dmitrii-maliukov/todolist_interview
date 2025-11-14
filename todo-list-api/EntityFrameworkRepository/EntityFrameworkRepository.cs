using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using TodoList.Core.Abstractions;
using TodoList.Core.Exceptions;
using TodoList.Core.Models;
using TodoList.EntityFrameworkRepository.Converters;

namespace TodoList.EntityFrameworkRepository;

public class EntityFrameworkRepository : IRepository
{
    private readonly TodoListDbContext _dbContext;

    public EntityFrameworkRepository(TodoListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // TODO: make pagination if time allowed
    public async Task<ReadOnlyCollection<TodoListModel>> GetAllTodoListsAsync(CancellationToken ct)
    {
        return (await _dbContext.TodoLists
            .Include(x => x.Items)
            .Select(x => x.ConvertToCoreListModel())
            .ToListAsync(ct))
            .AsReadOnly();
    }

    public async Task<TodoListModel> GetTodoListAsync(Guid id, CancellationToken ct)
    {
        var fetched = await _dbContext.TodoLists
            .SingleOrDefaultAsync(x => x.Id == id, ct);

        if (fetched == null)
            throw new DataNotFoundException($"Todo List {id} cannot be found");

        return fetched.ConvertToCoreListModel();
    }

    public async Task<TodoListModel> InsertTodoListAsync(
        CreateTodoListInfo todoListInfo,
        CancellationToken ct)
    {
        var entity = todoListInfo.ConvertToEntityModel();
        await _dbContext.TodoLists.AddAsync(entity, ct);
        await _dbContext.SaveChangesAsync(ct);

        return entity.ConvertToCoreListModel();
    }
}
