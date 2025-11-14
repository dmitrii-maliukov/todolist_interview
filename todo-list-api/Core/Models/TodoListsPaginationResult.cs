using System.Collections.ObjectModel;

namespace TodoList.Core.Models;

public record TodoListsPaginationResult(
    int TotalCount,
    int CurrentPage,
    ReadOnlyCollection<TodoListModel> TodoLists);