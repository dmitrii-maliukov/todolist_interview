namespace TodoList.EntityFrameworkRepository;

public class TodoListItemEntity
{
    public Guid Id { get; set; }
    public Guid TodoListId { get; set; }
    public required string Note { get; set; }
    public required bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }

    public required TodoListEntity TodoList { get; set; }
}