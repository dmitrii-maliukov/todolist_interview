namespace TodoList.Api.Models;

public class CreateTodoListRequest
{
    public CreateTodoListModel? TodoList { get; set; }

    public IEnumerable<CreateTodoListItemModel>? TodoItems { get; set; }
}