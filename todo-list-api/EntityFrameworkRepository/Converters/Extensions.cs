using TodoList.Core.Models;

namespace TodoList.EntityFrameworkRepository.Converters;

internal static class Extensions
{
    public static TodoListModel ConvertToCoreListModel(
            this TodoListEntity listEntity) =>
        new()
        {
            Id = listEntity.Id,
            Title = listEntity.Title,
            Description = listEntity.Description,
            CreatedAt = listEntity.CreatedAt,

            TodoItems = listEntity.Items
                .Select(x => x.ConvertToCoreListItemModel())
                .ToList().AsReadOnly()
        };

    public static TodoListItemModel ConvertToCoreListItemModel(
            this TodoListItemEntity listItemEntity) =>
        new()
        {
            Id = listItemEntity.Id,
            ListId = listItemEntity.TodoListId,
            Title = listItemEntity.Title,
            Description = listItemEntity.Description,
            IsCompleted = listItemEntity.IsCompleted,
            CreatedAt = listItemEntity.CreatedAt
        };
}