namespace TodoList.Api.Models;

public class GetApiTodoListsModel
{
    public IEnumerable<ApiTodoListModel> Items { get; set; } = [];
}