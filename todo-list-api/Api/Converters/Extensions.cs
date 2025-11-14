using TodoList.Api.Models;
using TodoList.Core.Models;

namespace TodoList.Api.Converters;

internal static class Extensions
{
    public static ApiTodoListItemModel ToApiTodoListItemModel(
            this TodoListItemModel todoListItem) =>
        new()
        {
            Id = todoListItem.Id,
            ListId = todoListItem.ListId,
            Title = todoListItem.Title,
            Description = todoListItem.Description,
            IsCompleted = todoListItem.IsCompleted,
            CreatedAt = todoListItem.CreatedAt
        };

    public static ApiTodoListModel ToApiTodoListModel(
            this TodoListModel todoList) =>
        new()
        {
            Id = todoList.Id,
            Title = todoList.Title,
            Description = todoList.Description,
            CreatedAt = todoList.CreatedAt,
            TodoItems = todoList.TodoItems.Select(x => x.ToApiTodoListItemModel()),
        };

    public static CreateTodoListInfo ToCoreTodoListModel(
        this CreateTodoListRequest todoListRequest)
    {
        var list = todoListRequest.TodoList!;
        var listItems = todoListRequest.TodoItems!
            .Select(x => new CreateTodoListItemInfo()
            {
                Title = x.Title!,
                Description = x.Description,
                IsCompleted = x.IsCompleted
            });

        return new()
        {
            Title = list.Title!,
            Description = list.Description,
            TodoItems = listItems
        };
    }

    public static GetApiTodoListsModel ToTodoListsPaginationResult(
            this TodoListsPaginationResult paginationResult) =>
        new GetApiTodoListsModel
        {
            TotalCount = paginationResult.TotalCount,
            CurrentPageNumber = paginationResult.CurrentPage,
            Items = paginationResult.TodoLists
                .Select(x => x.ToApiTodoListModel())
                .ToList().AsReadOnly()
        };

}