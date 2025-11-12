namespace TodoList.Core.Models;

public class TodoListModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public List<TodoListItemModel> TodoItems { get; set; } = new List<TodoListItemModel>();
}