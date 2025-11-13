using System.Collections.ObjectModel;

namespace TodoList.Core.Models;

public class TodoListModel
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public ReadOnlyCollection<TodoListItemModel> TodoItems { get; set; }
        = new List<TodoListItemModel>().AsReadOnly();
}