namespace TodoList.Core.Models;

public class CreateTodoListItemInfo
{
    public required string Note { get; set; }
    public bool IsCompleted { get; set; }
}