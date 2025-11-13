namespace TodoList.Core.Models;

public class CreateTodoListItemInfo
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
}