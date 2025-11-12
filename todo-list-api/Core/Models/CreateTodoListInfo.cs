namespace TodoList.Core.Models;

public class CreateTodoListInfo
{
    public string? Title { get; set; }
    public IEnumerable<CreateTodoListItemInfo> TodoItems { get; set; }
        = new List<CreateTodoListItemInfo>();
}