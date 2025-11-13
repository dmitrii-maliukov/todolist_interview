using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoList.EntityFrameworkRepository.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TodoLists",
                columns: new[] { "Id", "CreatedAt", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("60f2d96b-fdc2-4ac0-a6ba-75b9d28a73e2"), new DateTime(2025, 11, 12, 10, 25, 0, 0, DateTimeKind.Utc), "Got it from Hagrid", "Hogwart's first grader shopping list" },
                    { new Guid("d8037978-4e82-489c-bc2e-a1e22e66e1cb"), new DateTime(2025, 11, 12, 10, 28, 0, 0, DateTimeKind.Utc), null, "First grader books" }
                });

            migrationBuilder.InsertData(
                table: "TodoListItems",
                columns: new[] { "Id", "CreatedAt", "Description", "Title", "TodoListId" },
                values: new object[,]
                {
                    { new Guid("05d7dd78-25b5-4ead-9da7-b65bde9e247e"), new DateTime(2025, 11, 12, 10, 28, 0, 0, DateTimeKind.Utc), "by Quentin Trimble", "The Dark Forces: A Guide to Self-Protection", new Guid("d8037978-4e82-489c-bc2e-a1e22e66e1cb") },
                    { new Guid("51ffb482-7312-4330-aa24-975a8114bbb8"), new DateTime(2025, 11, 12, 10, 25, 0, 0, DateTimeKind.Utc), "pewter, standard size 2", "1 Cauldron", new Guid("60f2d96b-fdc2-4ac0-a6ba-75b9d28a73e2") },
                    { new Guid("6af576ec-2747-4566-9546-bc2438f4ac3c"), new DateTime(2025, 11, 12, 10, 25, 0, 0, DateTimeKind.Utc), "", "1 Wand", new Guid("60f2d96b-fdc2-4ac0-a6ba-75b9d28a73e2") },
                    { new Guid("9a8168f7-814f-4a09-9082-e820748e93b3"), new DateTime(2025, 11, 12, 10, 28, 0, 0, DateTimeKind.Utc), "by Emeric Switch", "A Beginner's Guide to Transfiguration", new Guid("d8037978-4e82-489c-bc2e-a1e22e66e1cb") },
                    { new Guid("9f107bb9-f666-44ff-a711-1a87cf78cfa0"), new DateTime(2025, 11, 12, 10, 25, 0, 0, DateTimeKind.Utc), "", "1 set of brass scales", new Guid("60f2d96b-fdc2-4ac0-a6ba-75b9d28a73e2") },
                    { new Guid("a7a73eb5-f57d-4f44-bc3b-7591e402f4b6"), new DateTime(2025, 11, 12, 10, 28, 0, 0, DateTimeKind.Utc), "by Adalbert Waffling", "Magical Theory", new Guid("d8037978-4e82-489c-bc2e-a1e22e66e1cb") },
                    { new Guid("aa4773e5-72b4-409a-a1e8-f63ff11821b0"), new DateTime(2025, 11, 12, 10, 28, 0, 0, DateTimeKind.Utc), "by Newt Scamander", "Fantastic Beasts and Where to Find Them", new Guid("d8037978-4e82-489c-bc2e-a1e22e66e1cb") },
                    { new Guid("ae11e864-495f-4355-9356-a51873c4df29"), new DateTime(2025, 11, 12, 10, 28, 0, 0, DateTimeKind.Utc), "by Arsenius Jigger", "Magical Drafts and Potions", new Guid("d8037978-4e82-489c-bc2e-a1e22e66e1cb") },
                    { new Guid("d6401c2a-6d89-4e9e-957a-55a93ff0f1ec"), new DateTime(2025, 11, 12, 10, 25, 0, 0, DateTimeKind.Utc), "An Owl or a Cat or a Toad", "Students may also bring a pet", new Guid("60f2d96b-fdc2-4ac0-a6ba-75b9d28a73e2") },
                    { new Guid("d7085cd7-a36f-4a76-b778-d9befe0bf332"), new DateTime(2025, 11, 12, 10, 28, 0, 0, DateTimeKind.Utc), "by Phyllida Spore", "One Thousand Magical Herbs and Fungi", new Guid("d8037978-4e82-489c-bc2e-a1e22e66e1cb") },
                    { new Guid("d7ede17d-d6bc-4bfa-ad6e-e9ecd7620287"), new DateTime(2025, 11, 12, 10, 28, 0, 0, DateTimeKind.Utc), "by Bathilda Bagshot", "A History of Magic", new Guid("d8037978-4e82-489c-bc2e-a1e22e66e1cb") },
                    { new Guid("e910a686-58c1-4986-9e12-f860d0774e96"), new DateTime(2025, 11, 12, 10, 28, 0, 0, DateTimeKind.Utc), "Grade 1 by Miranda Goshawk", "The Standard Book of Spells", new Guid("d8037978-4e82-489c-bc2e-a1e22e66e1cb") },
                    { new Guid("fbcad090-3928-470f-bad1-babc87dc14f4"), new DateTime(2025, 11, 12, 10, 25, 0, 0, DateTimeKind.Utc), "", "1 telescope", new Guid("60f2d96b-fdc2-4ac0-a6ba-75b9d28a73e2") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("05d7dd78-25b5-4ead-9da7-b65bde9e247e"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("51ffb482-7312-4330-aa24-975a8114bbb8"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("6af576ec-2747-4566-9546-bc2438f4ac3c"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("9a8168f7-814f-4a09-9082-e820748e93b3"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("9f107bb9-f666-44ff-a711-1a87cf78cfa0"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("a7a73eb5-f57d-4f44-bc3b-7591e402f4b6"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("aa4773e5-72b4-409a-a1e8-f63ff11821b0"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("ae11e864-495f-4355-9356-a51873c4df29"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("d6401c2a-6d89-4e9e-957a-55a93ff0f1ec"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("d7085cd7-a36f-4a76-b778-d9befe0bf332"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("d7ede17d-d6bc-4bfa-ad6e-e9ecd7620287"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("e910a686-58c1-4986-9e12-f860d0774e96"));

            migrationBuilder.DeleteData(
                table: "TodoListItems",
                keyColumn: "Id",
                keyValue: new Guid("fbcad090-3928-470f-bad1-babc87dc14f4"));

            migrationBuilder.DeleteData(
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: new Guid("60f2d96b-fdc2-4ac0-a6ba-75b9d28a73e2"));

            migrationBuilder.DeleteData(
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: new Guid("d8037978-4e82-489c-bc2e-a1e22e66e1cb"));
        }
    }
}
