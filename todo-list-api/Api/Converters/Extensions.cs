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
            Note = todoListItem.Note,
            IsCompleted = todoListItem.IsCompleted
        };

    public static ApiTodoListModel ToApiTodoListModel(
            this TodoListModel todoList) =>
        new()
        {
            Id = todoList.Id,
            Title = todoList.Title,
            TodoItems = todoList.TodoItems.Select(x => x.ToApiTodoListItemModel()),
        };

    public static CreateTodoListInfo ToCoreTodoListModel(
            this CreateTodoListRequest newTodoList) =>
        new()
        {
            Title = newTodoList.Title,
            TodoItems = newTodoList.TodoItems?
                .Select(x => new CreateTodoListItemInfo() { Note = x, IsCompleted = false }) ?? []
        };
}