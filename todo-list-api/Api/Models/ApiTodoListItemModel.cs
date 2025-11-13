namespace TodoList.Api.Models;

public class ApiTodoListItemModel
{
    public Guid Id { get; set; }
    public required string Note { get; set; }
    public bool IsCompleted { get; set; }
}