using System.Collections.ObjectModel;

namespace TodoList.Api.Models;

public class ApiTodoListModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public IEnumerable<ApiTodoListItemModel> TodoItems { get; set; } = [];
}