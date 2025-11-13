using Microsoft.EntityFrameworkCore;

namespace TodoList.EntityFrameworkRepository;

public static class DataSeeding
{
    internal static void SeedInitialData(ModelBuilder modelBuilder)
    {
        AddFirstGraderShoppingList(modelBuilder);
        AddBooksList(modelBuilder);
    }

    private static void AddFirstGraderShoppingList(ModelBuilder modelBuilder)
    {
        var listId = Guid.NewGuid();
        var createdAt = DateTime.UtcNow.AddDays(-2);

        modelBuilder
            .Entity<TodoListEntity>()
            .HasData(new TodoListEntity
            {
                Id = listId,
                Title = "Hogwart's first grader shopping list",
                Description = "Got it from Hagrid",
                CreatedAt = createdAt
            });

        List<(string note, string description)> shoppingListItems = [
            ("1 Wand", ""),
            ("1 Cauldron", "pewter, standard size 2"),
            ("1 telescope", ""),
            ("1 set of brass scales", ""),
            ("Students may also bring a pet", "An Owl or a Cat or a Toad")
        ];
        modelBuilder
            .Entity<TodoListItemEntity>()
            .HasData(BuildTodoItems(listId, createdAt, shoppingListItems));
    }

    private static void AddBooksList(ModelBuilder modelBuilder)
    {
        var listId = Guid.NewGuid();
        var createdAt = DateTime.UtcNow.AddDays(-2).AddMinutes(5);

        modelBuilder
            .Entity<TodoListEntity>()
            .HasData(new TodoListEntity
            {
                Id = listId,
                Title = "First grader books",
                CreatedAt = createdAt
            });

        List<(string note, string description)> booksListItems = [
            ("The Standard Book of Spells", "Grade 1 by Miranda Goshawk"),
            ("A History of Magic", "by Bathilda Bagshot"),
            ("Magical Theory", "by Adalbert Waffling"),
            ("A Beginner's Guide to Transfiguration", "by Emeric Switch"),
            ("One Thousand Magical Herbs and Fungi", "by Phyllida Spore"),
            ("Magical Drafts and Potions", "by Arsenius Jigger"),
            ("Fantastic Beasts and Where to Find Them", "by Newt Scamander"),
            ("The Dark Forces: A Guide to Self-Protection", "by Quentin Trimble")
        ];
        modelBuilder
            .Entity<TodoListItemEntity>()
            .HasData(BuildTodoItems(listId, createdAt, booksListItems));

    }

    private static IEnumerable<TodoListItemEntity> BuildTodoItems(
        Guid listId,
        DateTime createdAt,
        IEnumerable<(string note, string description)> todoNotes)
    {
        return todoNotes
            .Select(todoItem => new TodoListItemEntity()
            {
                Id = Guid.NewGuid(),
                TodoListId = listId,
                Title = todoItem.note,
                Description = todoItem.description,
                IsCompleted = false,
                CreatedAt = createdAt
            });
    }
}