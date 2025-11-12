namespace TodoList.Core.Models;

public class TodoListItemModel
{
    public Guid Id { get; set; }
    public Guid ListId { get; set; }
    public required string Note { get; set; }
    public bool Done { get; set; }
}