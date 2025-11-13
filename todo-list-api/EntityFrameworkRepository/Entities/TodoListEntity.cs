namespace TodoList.EntityFrameworkRepository;

public class TodoListEntity
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<TodoListItemEntity> Items { get; set; }
        = new List<TodoListItemEntity>();
}