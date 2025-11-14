namespace TodoList.Api.Models;

public class GetApiTodoListsModel
{
    public int TotalCount { get; set; }
    public int CurrentPageNumber { get; set; }
    public IEnumerable<ApiTodoListModel> Items { get; set; } = [];
}