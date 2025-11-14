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
        var listId = Guid.Parse("60f2d96b-fdc2-4ac0-a6ba-75b9d28a73e2");
        var createdAt = new DateTime(2025, 11, 12, 10, 25, 0, DateTimeKind.Utc);

        modelBuilder
            .Entity<TodoListEntity>()
            .HasData(new TodoListEntity
            {
                Id = listId,
                Title = "Hogwart's first grader shopping list",
                Description = "Got it from Hagrid",
                CreatedAt = createdAt
            });

        List<(string id, string note, string description, bool? isCompleted)> shoppingListItems = [
            ("6af576ec-2747-4566-9546-bc2438f4ac3c", "1 Wand", "", false),
            ("51ffb482-7312-4330-aa24-975a8114bbb8", "1 Cauldron", "pewter, standard size 2", false),
            ("fbcad090-3928-470f-bad1-babc87dc14f4", "1 telescope", "", false),
            ("9f107bb9-f666-44ff-a711-1a87cf78cfa0", "1 set of brass scales", "", true),
            ("d6401c2a-6d89-4e9e-957a-55a93ff0f1ec", "Students may also bring a pet", "An Owl or a Cat or a Toad", false)
        ];
        modelBuilder
            .Entity<TodoListItemEntity>()
            .HasData(BuildTodoItems(listId, createdAt, shoppingListItems));
    }

    private static void AddBooksList(ModelBuilder modelBuilder)
    {
        var listId = Guid.Parse("d8037978-4e82-489c-bc2e-a1e22e66e1cb");
        var createdAt = new DateTime(2025, 11, 12, 10, 28, 0, DateTimeKind.Utc);

        modelBuilder
            .Entity<TodoListEntity>()
            .HasData(new TodoListEntity
            {
                Id = listId,
                Title = "First grader books",
                CreatedAt = createdAt
            });

        List<(string id, string note, string description, bool? isCompleted)> booksListItems = [
            ("e910a686-58c1-4986-9e12-f860d0774e96", "The Standard Book of Spells", "Grade 1 by Miranda Goshawk", true),
            ("d7ede17d-d6bc-4bfa-ad6e-e9ecd7620287", "A History of Magic", "by Bathilda Bagshot", false),
            ("a7a73eb5-f57d-4f44-bc3b-7591e402f4b6", "Magical Theory", "by Adalbert Waffling", false),
            ("9a8168f7-814f-4a09-9082-e820748e93b3", "A Beginner's Guide to Transfiguration", "by Emeric Switch", false),
            ("d7085cd7-a36f-4a76-b778-d9befe0bf332", "One Thousand Magical Herbs and Fungi", "by Phyllida Spore", true),
            ("ae11e864-495f-4355-9356-a51873c4df29", "Magical Drafts and Potions", "by Arsenius Jigger", true),
            ("aa4773e5-72b4-409a-a1e8-f63ff11821b0", "Fantastic Beasts and Where to Find Them", "by Newt Scamander", false),
            ("05d7dd78-25b5-4ead-9da7-b65bde9e247e", "The Dark Forces: A Guide to Self-Protection", "by Quentin Trimble", false)
        ];
        modelBuilder
            .Entity<TodoListItemEntity>()
            .HasData(BuildTodoItems(listId, createdAt, booksListItems));

    }

    private static IEnumerable<TodoListItemEntity> BuildTodoItems(
        Guid listId,
        DateTime createdAt,
        IEnumerable<(string id, string note, string description, bool? isCompleted)> todoNotes)
    {
        return todoNotes
            .Select(todoItem => new TodoListItemEntity()
            {
                Id = Guid.Parse(todoItem.id),
                TodoListId = listId,
                Title = todoItem.note,
                Description = todoItem.description,
                IsCompleted = todoItem.isCompleted ?? false,
                CreatedAt = createdAt
            });
    }
}