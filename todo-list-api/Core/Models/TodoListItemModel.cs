namespace TodoList.Core.Models;

public class TodoListItemModel
{
    public Guid Id { get; set; }
    public required string Note { get; set; }
    public bool IsCompleted { get; set; }
}