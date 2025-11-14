namespace TodoList.Core.Models;

public record GetTodoListsFilter
{
    private const int _defaultPageSize = 10;
    private const int _defaultCurrentPage = 1;

    public int PageSize { get; set; }
    public int CurrentPage { get; set; }

    public GetTodoListsFilter(int? pageSize, int? currentPage)
    {
        PageSize = pageSize ?? _defaultPageSize;
        CurrentPage = currentPage ?? _defaultCurrentPage;
    }
}