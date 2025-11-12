namespace TodoList.Core.Models;

public class CreateTodoListItemInfo
{
    public required string Note { get; set; }
    public bool Done { get; set; }
}