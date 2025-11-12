namespace TodoList.Api.Models;

public class CreateTodoListRequest
{
    public string? Title { get; set; }
    public IEnumerable<string>? TodoItems { get; set; }
}