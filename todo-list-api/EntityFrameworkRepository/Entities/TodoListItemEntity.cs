namespace TodoList.EntityFrameworkRepository;

public class TodoListItemEntity
{
    public Guid Id { get; set; }
    public Guid TodoListId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }

    public TodoListEntity TodoList { get; set; } = null!;
}