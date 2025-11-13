namespace TodoList.Api.Models;

public class ApiTodoListModel
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<ApiTodoListItemModel> TodoItems { get; set; } = [];
}