namespace TodoList.Api.Models;

public class ApiTodoListItemModel
{
    public Guid Id { get; set; }
    public Guid ListId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
}