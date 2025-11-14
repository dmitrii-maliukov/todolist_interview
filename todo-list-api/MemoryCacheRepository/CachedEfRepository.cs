using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TodoList.Core.Abstractions;
using TodoList.Core.Models;

namespace TodoList.MemoryCacheRepository;

internal class CachedEfRepository : IRepository
{
    private static readonly TimeSpan _cacheInvalidationTime = TimeSpan.FromMinutes(1);
    private static int _cacheVersion = 0;

    private readonly IRepository _repository;
    private readonly IMemoryCache _memoryCache;
    private readonly ILogger _logger;

    public CachedEfRepository(
        IRepository repository,
        IMemoryCache memoryCache,
        ILogger<CachedEfRepository> logger)
    {
        _repository = repository;
        _memoryCache = memoryCache;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<TodoListsPaginationResult> GetTodoListsAsync(
        GetTodoListsFilter filter,
        CancellationToken ct)
    {
        var cacheKey = GetVersionedKey(filter.ToString());
        if (_memoryCache.TryGetValue(cacheKey, out TodoListsPaginationResult? paginationResult))
        {
            _logger.LogDebug("Got paginated data from cache");
            return paginationResult!;
        }

        _logger.LogDebug("Fetching paginated data from db");
        var result = await _repository.GetTodoListsAsync(filter, ct);
        _memoryCache.Set(cacheKey, result, _cacheInvalidationTime);

        return result;
    }

    /// <inheritdoc />
    public async Task<TodoListModel> GetTodoListAsync(Guid id, CancellationToken ct)
    {
        if (_memoryCache.TryGetValue(id, out TodoListModel? todoList))
        {
            _logger.LogDebug("Got single record from cache");
            return todoList!;
        }

        _logger.LogDebug("Fetching single record data from db");
        var result = await _repository.GetTodoListAsync(id, ct);
        _memoryCache.Set(id.ToString(), result, _cacheInvalidationTime);

        return result;
    }

    /// <inheritdoc />
    public async Task<TodoListModel> InsertTodoListAsync(
        CreateTodoListInfo todoListInfo,
        CancellationToken ct)
    {
        var result = await _repository.InsertTodoListAsync(todoListInfo, ct);

        _logger.LogDebug("Cache invalidating");
        InvalidateCache();

        return result;
    }

    private string GetVersionedKey(string key) => $"v{_cacheVersion}:{key}";
    private void InvalidateCache() => _cacheVersion++;
}
